using System;

namespace MagicTower
{
    using System;
    public class EnergyFieldSystem
    {
        public static float MaxEnergyField(int[] heights)
        {
            // 在这⾥实现你的代码

            int leftIndex = 0;
            int rightIndex = heights.Length - 1;
            float result = 0;
            while (leftIndex < rightIndex) 
            {
                int leftH = heights[leftIndex];
                int rightH = heights[rightIndex];
                result = MathF.Max(result, (float)(leftH + rightH) * (rightIndex - leftIndex) / 2);

                if (leftH < rightH)
                {
                    while (leftIndex < rightIndex)
                    {
                        leftIndex++;
                        if (heights[leftIndex] > leftH)
                        {
                            break;
                        }
                    }
                }
                else 
                {
                    while (leftIndex < rightIndex)
                    {
                        rightIndex--;
                        if (heights[rightIndex] > rightH)
                        {
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
    // 单元测试
    public class EnergyFieldSystemTests
    {
        static public void TestMaxEnergyField()
        {
            // 在这⾥编写测试⽤例
            int[] heights = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Console.WriteLine(EnergyFieldSystem.MaxEnergyField(heights));
        }

        static void Main() 
        {
            TestMaxEnergyField();
        }
    }
}
