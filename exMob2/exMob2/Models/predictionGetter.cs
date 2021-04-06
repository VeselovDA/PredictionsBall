using System;
using System.Collections.Generic;
using System.Text;

namespace exMob2.Models
{
    class predictionGetter
    {
        Random random = new Random();
        List<string> predictionList = new List<string>() { "Приятного аппетита", "Не стоит этого делать","Забей на это","Должно сработать", "Полухин применит к тебе меры", "Тебя хранит аниме", "Ты дед инсайд", "Поешь говна но поменьше", "Поешь говна", "Искусство сдохнет", "Музыка воскреснет" };
        List<string> processList = new List<string>() { "Процесс придумывания:", "Гуглю рандомайзер:", "Не подглядывай:", "Поиск туза:", "Мда.....", " Соединение с крышей:" };
        public string Prediction
            {
            get { return  predictionList[random.Next(predictionList.Count)]; }
            }
        public string Process
        {
            get { return processList[random.Next(processList.Count)]; }
        }
    }
}
