using System;
using System.Collections.Generic;

namespace DataTypes
{

    public class Variant
    {
        public enum VariantDataType
        {
            INTEGER = 0, DOUBLE = 1, STRING = 2, BOOL = 3, STRINGLIST = 5, INTLIST = 6, DOUBLELIST = 7, UNDEFINED = 8
        }
        public Variant()
        {
            mData = 0;
            mDataType = 0;
            mUnit = "";

        }
        public Variant(int value, string unit)
        {
            mDataType = VariantDataType.INTEGER;

            mData = value;
            mUnit = unit;
        }
        public Variant(double value, string unit)
        {
            mDataType = VariantDataType.DOUBLE;

            mData = value;
            mUnit = unit;
        }

        public Variant(string value)
        {
            mDataType = VariantDataType.STRING;

            mData = value;
            mUnit = "";
        }

        public Variant(bool value)
        {
            mDataType = VariantDataType.BOOL;

            mData = value;
            mUnit = "";
        }
        public Variant(List<string> value)
        {
            mDataType = VariantDataType.STRINGLIST;

            mData = value;
        }

        public Variant(List<int> value)
        {
            mDataType = VariantDataType.INTLIST;

            mData = value;
        }
        public Variant(List<double> value)
        {
            mDataType = VariantDataType.DOUBLELIST;

            mData = value;
        }


        public int getInt()
        {
            return Convert.ToInt32(mData);
        }
        public double getDouble()
        {
            return Convert.ToDouble(mData);
        }
        public string getString()
        {
            return Convert.ToString(mData);
        }

        public bool getBool()
        {
            return Convert.ToBoolean(mData);
        }


        public List<string> getStringList()
        {
            if (mDataType == VariantDataType.STRINGLIST) return (List<string>)mData;
            else return new List<string>() { Convert.ToString(mData) };
        }

        public List<int> getIntList()
        {
            if (mDataType == VariantDataType.INTLIST) return (List<int>)mData;
            else return new List<int>() { Convert.ToInt32(mData) };
        }
        public List<double> getDoubleList()
        {
            if (mDataType == VariantDataType.DOUBLELIST) return (List<double>)mData;
            else return new List<double>() { Convert.ToDouble(mData) };
        }

        public void setInt(int value)
        {
            mData = value;
            mDataType = VariantDataType.INTEGER;
        }
        public void setDouble(double value)
        {
            mData = value;
            mDataType = VariantDataType.DOUBLE;
        }
        public void setString(string value)
        {
            mData = value;
            mDataType = VariantDataType.STRING;
        }
        public void setBool(bool value)
        {
            mData = value;
            mDataType = VariantDataType.BOOL;
        }
        public void setStringList(List<string> value)
        {
            mData = value;
            mDataType = VariantDataType.STRINGLIST;
        }

        public void setIntList(List<int> value)
        {
            mData = value;
            mDataType = VariantDataType.INTLIST;
        }

        public void setDoubleList(List<double> value)
        {
            mData = value;
            mDataType = VariantDataType.DOUBLELIST;
        }


        public VariantDataType getDataType()
        {
            return mDataType;
        }


        public string getUnit()
        {
            return mUnit;
        }
        private object mData;
        private VariantDataType mDataType;
        private string mUnit;



    }

    class VariantBindingProperties
    {
        public VariantBindingProperties(Variant v)
        {
            data = v;
        }

        public int asInteger
        {
            set
            {
                data.setInt(value);
            }
            get
            {
                return data.getInt();
            }
        }

        public double asDouble
        {
            set
            {
                data.setDouble(value);
            }
            get
            {
                return data.getDouble();
            }
        }

        public string asString
        {
            set
            {
                data.setString(value);
            }
            get
            {
                return data.getString();
            }
        }

        public bool asBool
        {
            set
            {
                data.setBool(value);
            }
            get
            {
                return data.getBool();
            }
        }

        public List<string> asStringList
        {
            set
            {
                data.setStringList(value);
            }
            get
            {
                return data.getStringList();
            }
        }
        public List<int> asIntList
        {
            set
            {
                data.setIntList(value);
            }
            get
            {
                return data.getIntList();
            }
        }
        public List<double> asDoubleList
        {
            set
            {
                data.setDoubleList(value);
            }
            get
            {
                return data.getDoubleList();
            }
        }
        private Variant data;
    }
}