using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Eos.Airdrop.Manager
{

    [JsonConverter(typeof(CustomJsonConverter))]
    public class Asset : ICustomJson, IComparable, IComparable<Asset>, IComparable<decimal>
    {
        private static readonly Regex MultyZeroRegex = new Regex("^0{2,}");
        private decimal? _doubleCash;

        public long Amount { get; private set; }

        public byte Decimals { get; private set; }

        public string Currency { get; private set; }

        public decimal ValueDouble => _doubleCash ?? (_doubleCash = ToDecimal()).Value;


        public Asset() { }

        public Asset(string value)
        {
            InitFromString(value, CultureInfo.InvariantCulture);
        }

        public Asset(string value, CultureInfo cultureInfo)
        {
            InitFromString(value, cultureInfo);
        }

        public Asset(long amount, byte decimals, string currency)
        {
            Amount = amount;
            Currency = currency.ToUpper();
            Decimals = decimals;
        }


        public override string ToString()
        {
            return ToString(CultureInfo.InvariantCulture);
        }

        public string ToString(CultureInfo cultureInfo)
        {
            var dig = ToDoubleString(cultureInfo);
            return string.IsNullOrEmpty(Currency) ? dig : $"{dig} {Currency}";
        }

        public void InitFromString(string value)
        {
            InitFromString(value, CultureInfo.InvariantCulture);
        }

        public void InitFromString(string value, CultureInfo cultureInfo)
        {
            value = MultyZeroRegex.Replace(value, "0");
            var kv = value.Split(' ');

            var buf = kv[0]
                .Replace(cultureInfo.NumberFormat.NumberDecimalSeparator, string.Empty)
                .Replace(cultureInfo.NumberFormat.NumberGroupSeparator, string.Empty);

            var charLenAftSeparator = kv[0].LastIndexOf(cultureInfo.NumberFormat.NumberDecimalSeparator, StringComparison.OrdinalIgnoreCase);
            if (charLenAftSeparator > 0)
                Decimals = (byte)(buf.Length - charLenAftSeparator);
            Amount = long.Parse(buf);
            Currency = kv.Length > 1 ? kv[1].ToUpper() : string.Empty;
        }

        public string ToDoubleString()
        {
            return ToDoubleString(CultureInfo.InvariantCulture);
        }

        public string ToDoubleString(CultureInfo cultureInfo)
        {
            var dig = Amount.ToString();
            if (Decimals > 0)
            {
                if (dig.Length <= Decimals)
                {
                    var prefix = new string('0', Decimals - dig.Length + 1);
                    dig = prefix + dig;
                }
                dig = dig.Insert(dig.Length - Decimals, cultureInfo.NumberFormat.NumberDecimalSeparator);
            }

            return dig;
        }

        public decimal ToDecimal()
        {
            return ToDecimal(CultureInfo.InvariantCulture);
        }

        public decimal ToDecimal(CultureInfo cultureInfo)
        {
            return decimal.Parse(ToDoubleString(cultureInfo), cultureInfo);
        }



        #region operations

        public static Asset operator +(Asset asset1, Asset asset2)
        {
            asset1.Normalize(asset2);
            return new Asset(asset1.Amount + asset2.Amount, asset1.Decimals, asset1.Currency);
        }

        public static Asset operator -(Asset asset1, Asset asset2)
        {
            asset1.Normalize(asset2);
            return new Asset(asset1.Amount - asset2.Amount, asset1.Decimals, asset1.Currency);
        }

        public static bool operator <=(Asset asset1, decimal value)
        {
            return asset1.CompareTo(value) <= 0;
        }

        public static bool operator >=(Asset asset1, decimal value)
        {
            return asset1.CompareTo(value) >= 0;
        }

        public static bool operator <(Asset asset1, decimal value)
        {
            return asset1.CompareTo(value) < 0;
        }

        public static bool operator >(Asset asset1, decimal value)
        {
            return asset1.CompareTo(value) > 0;
        }
        #endregion

        public static Asset Sum(Asset[] assets)
        {
            if (assets == null || !assets.Any())
                throw new ArithmeticException();

            var maxDec = assets.Max(a => a.Decimals);
            long sum = 0;
            for (int i = 0; i < assets.Length; i++)
            {
                var asset = assets[i];
                asset.Normalize(maxDec);
                sum += asset.Amount;
            }
            return new Asset(sum, maxDec, assets[0].Currency);
        }

        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            InitFromString(value);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            var value = ToString();
            writer.WriteValue(value);
        }

        #endregion

        #region IComparable

        public int CompareTo(object obj)
        {
            if (obj is Asset asset)
                return CompareTo(asset);

            throw new NotSupportedException();
        }

        public int CompareTo(Asset other)
        {
            Normalize(other);
            return Amount.CompareTo(other.Amount);
        }

        public int CompareTo(decimal other)
        {
            return ValueDouble.CompareTo(other);
        }

        #endregion


        private void Normalize(Asset other)
        {
            if (!other.Currency.Equals(Currency))
                throw new NotSupportedException();

            if (other.Decimals > Decimals)
            {
                Amount *= (int)Math.Pow(10, other.Decimals - Decimals);
                Decimals = other.Decimals;
            }
            else if (other.Decimals < Decimals)
            {
                other.Amount *= (int)Math.Pow(10, Decimals - other.Decimals);
                other.Decimals = Decimals;
            }
        }

        private void Normalize(byte decimals)
        {
            if (decimals > Decimals)
            {
                Amount *= (int)Math.Pow(10, decimals - Decimals);
                Decimals = decimals;
            }
        }

    }
}