using System;

namespace MagicTalent
{
    public class TalentAssessmentSystem
    {
        public static double FindMedianTalentIndex(int[] fireAbility, int[] iceAbility)
        {
            // 在这⾥实现你的代码
            int count = fireAbility.Length + iceAbility.Length;
            bool even = false;//偶数
            if (count % 2 == 0) 
            {
                even = true;
            }
            int midCount = count / 2 + 1;
            int fireIndex = 0;
            int iceIndex = 0;
            double result = 0;
            while (fireIndex < fireAbility.Length && iceIndex < iceAbility.Length) 
            {
                int nowNum;
                if (fireAbility[fireIndex] < iceAbility[iceIndex])
                {
                    nowNum = fireAbility[fireIndex];
                    midCount--;
                    fireIndex++;
                }
                else 
                {
                    nowNum = iceAbility[iceIndex];
                    midCount--;
                    iceIndex++;
                }
                if (even && midCount == 1) 
                {
                    result = nowNum;
                }
                if (even && midCount == 0) 
                {
                    result = (result + nowNum) / 2;
                    return result;
                }
                if (!even && midCount == 0) 
                {
                    result = nowNum;
                    return result;
                }
            }
            while (fireIndex < fireAbility.Length) 
            {
                int nowNum = fireAbility[fireIndex];
                midCount--;
                if (even && midCount == 1)
                {
                    result = nowNum;
                }
                if (even && midCount == 0)
                {
                    result = (result + nowNum) / 2;
                    return result;
                }
                if (!even && midCount == 0)
                {
                    result = nowNum;
                    return result;
                }
                fireIndex++;
            }
            while (iceIndex < iceAbility.Length)
            {
                int nowNum = iceAbility[iceIndex];
                midCount--;
                if (even && midCount == 1)
                {
                    result = nowNum;
                }
                if (even && midCount == 0)
                {
                    result = (result + nowNum) / 2;
                    return result;
                }
                if (!even && midCount == 0)
                {
                    result = nowNum;
                    return result;
                }
                iceIndex++;
            }
            return result;
        }
    }
    // 单元测试
    public class TalentAssessmentSystemTests
    {
        static public void TestFindMedianTalentIndex()
        {
            // 在这⾥编写测试⽤例
            int[] fire = { 1, 3, 7, 9, 11 };
            int[] ice = { 2, 4, 8, 10, 12, 14 };

            Console.WriteLine(TalentAssessmentSystem.FindMedianTalentIndex(fire, ice));

            int[] fire1 = { 1, 2, 3, 4, 5 };
            int[] ice1 = { 6, 6, 8, 10, 12 };
            Console.WriteLine(TalentAssessmentSystem.FindMedianTalentIndex(fire1, ice1));
        }

        static void Main() 
        {
            TestFindMedianTalentIndex();
        }
    }
}
