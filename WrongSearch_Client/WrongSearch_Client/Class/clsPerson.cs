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

        public int[] room=new int[4];
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
            room[0] = -1; // 방번호
            room[1] = 0; // 플레이어 순서 ( 0: 방장, 1: 참가자 )
            room[2] = 0; // 등수
            room[3] = 0; // 플레이어 숫자
            elo = 1200;
        }

        public void UpdateElo(int OppElo, string result)
        {
            int gap = OppElo-this.elo;
            double Exp = 1/(1+ Math.Pow(10, gap/400));

            if (result == "승리")
                elo = this.elo + (int)(16 * (1-Exp));
            else
                elo = this.elo + (int)(16 * (0-Exp));
        }
    }
}
