using System;

class Program
{
    private static void Main(string[] args)
    {
        game_engine();
    }

    static void game_engine()
    {
        int tien = 100; // von ban dau
        int soTranThang = 0;
        int soTranThua = 0;

        Console.WriteLine("Chao mung ban den voi tro choi doan so ^^");

        do
        {
            Console.WriteLine($"\nBan hien co: {tien}$");

            // het tien thi dung
            if (tien <= 0)
            {
                Console.WriteLine("Ban da het tien, game over!");
                break;
            }

            Console.WriteLine("Level:\n\t1-Kho: 4 lan choi\n\t2-Trung binh: 7 lan\n\t3-De: 10 lan");
            int level = NhapSo("Chon level (1-3): ", 1, 3);

            int soLanChoi = (level == 1 ? 4 : (level == 2 ? 7 : 10));

            // sinh so ngau nhien [1..100]
            Random rnd = new Random();
            int soMay = rnd.Next(1, 101);

            bool is_win = false;

            for (int i = 1; i <= soLanChoi; i++)
            {
                int soNguoi = NhapSo($"Luot {i}/{soLanChoi}, doan so (1-100): ", 1, 100);

                if (soNguoi == soMay)
                {
                    is_win = true;
                    Console.WriteLine("Ban doan dung! Genius!");
                    tien += 10; // thang duoc +10$
                    soTranThang++;
                    break;
                }
                else if (soNguoi > soMay)
                {
                    Console.WriteLine("So ban doan lon hon so may.");
                }
                else
                {
                    Console.WriteLine("So ban doan nho hon so may.");
                }
            }

            if (!is_win)
            {
                Console.WriteLine($"Ban da thua! So may la: {soMay}");
                tien -= 10; // thua -10$
                soTranThua++;
            }

            Console.Write("\nBan co muon choi tiep khong? (y/n): ");
            string ans = Console.ReadLine().Trim().ToLower();
            if (ans != "y") break;

        } while (true);

        Console.WriteLine($"\nKet thuc game. So tien con lai: {tien}$");
        Console.WriteLine($"Thong ke: {soTranThang} tran thang, {soTranThua} tran thua");
    }

    // Ham nhap so an toan
    static int NhapSo(string msg, int min, int max)
    {
        int num;
        while (true)
        {
            Console.Write(msg);
            string input = Console.ReadLine();
            if (int.TryParse(input, out num) && num >= min && num <= max)
            {
                return num;
            }
            Console.WriteLine($"Vui long nhap so trong khoang [{min} - {max}]!");
        }
    }
}
