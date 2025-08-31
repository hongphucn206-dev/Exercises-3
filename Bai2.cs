using System;

class Bai2
{
    static void Main(string[] args)
    {
        dice_game();
    }

    public static void dice_game()
    {
        int tien = 100; // von ban dau
        int soTranThang = 0;
        int soTranThua = 0;

        Console.WriteLine("Chao mung ban den voi tro choi Tai - Xiu");

        do
        {
            Console.WriteLine($"\nBan hien co: {tien}$");

            if (tien <= 0)
            {
                Console.WriteLine("Ban da het tien, game over!");
                break;
            }

            // may gieo 2 con xuc sac
            Random rnd = new Random();
            int die1 = rnd.Next(1, 7);
            int die2 = rnd.Next(1, 7);
            int tong = die1 + die2;

            // nguoi choi doan
            Console.Write("Ban doan gi (tai/xiu/5): ");
            string doan = Console.ReadLine().Trim().ToLower();

            string ketQua;
            if (tong > 5) ketQua = "tai";
            else if (tong < 5) ketQua = "xiu";
            else ketQua = "5";

            Console.WriteLine($"May gieo: {die1} + {die2} = {tong}  => {ketQua.ToUpper()}");

            if (doan == ketQua)
            {
                if (ketQua == "5")
                {
                    tien += 15; // trung 5 thi +15
                    Console.WriteLine("Ban doan dung 5, duoc +15$");
                }
                else
                {
                    tien += 5;
                    Console.WriteLine("Ban doan dung, duoc +5$");
                }
                soTranThang++;
            }
            else
            {
                tien -= 5;
                Console.WriteLine("Ban doan sai, bi tru -5$");
                soTranThua++;
            }

            // hoi choi tiep
            Console.Write("\nBan co muon choi tiep khong? (y/n): ");
            string tl = Console.ReadLine().Trim().ToLower();
            if (tl != "y")
            {
                Console.WriteLine("Bye, hen gap lai!");
                break;
            }

        } while (true);

        // bao cao cuoi cung
        Console.WriteLine("\n===== BAO CAO =====");
        Console.WriteLine($"So tien con lai: {tien}$");
        Console.WriteLine($"So tran thang: {soTranThang}");
        Console.WriteLine($"So tran thua: {soTranThua}");
    }
}
