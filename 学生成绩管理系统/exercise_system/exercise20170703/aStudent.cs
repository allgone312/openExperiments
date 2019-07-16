using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exercise20170703
{
    public class aStudent
    {

        //自增标识码
        public long mainKey;
        public long idNumber;
        public string name;
        public DateTime time;
        public string sex;
        public DateTime birthDate;
        public string nation;
        public string birthPlace;
        public int mlId;
        //生成
        public long classId;
        public long studId;
        //选填
        public string address;
        public long phone;


        //构造函数
        public aStudent(long _idNumber,string _name,DateTime _time,string _sex,DateTime _birthDate,
            string _nation,string _birthPlace,int _mlId )
        {
            idNumber = _idNumber;
            name = _name;
            time = _time;
            sex = _sex;
            birthDate = _birthDate;
            nation = _nation;
            birthPlace = _birthPlace;
            mlId = _mlId;
        }
        public aStudent() { }
    }
}