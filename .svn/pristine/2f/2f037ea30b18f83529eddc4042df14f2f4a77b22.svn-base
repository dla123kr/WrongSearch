using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WrongSearch_Server.Class
{
    public class clsPerson
    {
        public string classNumber;
        public string password;

        public string name;
        public string phone;
        public string gender;

        public int[] room = new int[4];
        public int elo;

        public clsPerson() { }
        public clsPerson(string _classNumber, string _password,
            string _name, string _gender, string _phone)
        {
            classNumber = _classNumber;
            password = _password;
            name = _name;
            gender = _gender;
            phone = _phone;

            // 방번호, 플레이어, 등수, 플레이어숫자
            room[0] = -1;
            room[1] = 0;
            room[2] = 0;
            room[3] = 0;

            elo = 1200;

        }
        public clsPerson(string _classNumber, string _password,
            string _name, string _gender, string _phone, int _elo)
        {
            classNumber = _classNumber;
            password = _password;
            name = _name;
            gender = _gender;
            phone = _phone;
            elo = _elo;

            // 방번호, 플레이어, 등수
            room[0] = -1;
            room[1] = 0;
            room[2] = 0;



        }
    }
}
