using mod8;

public class Program
{
    private static void Main(string[] args)
    {
        CovidConfig covig = new CovidConfig();

        Console.Write("Berapa suhu badan anda saat ini?" +
            " Dalam nilai "+covig.konfig.satuan_suhu+" ");
        double suhu_sekarang = Convert.ToDouble(Console.ReadLine());
        Console.Write("Berapa hari yang lalu (perkiraan) " +
            "anda terakhir memiliki gejala demam? ");
        int gejala_demam = Convert.ToInt32(Console.ReadLine());
        string pesan_keluar = covig.konfig.pesan_ditolak;
        if (gejala_demam > covig.konfig.batas_hari_demam)
        {
            if (covig.konfig.satuan_suhu == "celcius")
            {
                pesan_keluar = (suhu_sekarang >= 36.5 && suhu_sekarang <= 37.5) ?
                    covig.konfig.pesan_diterima : covig.konfig.pesan_ditolak;
            }else if(covig.konfig.satuan_suhu == "fahrenheit")
            {
                pesan_keluar = (suhu_sekarang >= 97.7 && suhu_sekarang <= 99.5) ?
                    covig.konfig.pesan_diterima : covig.konfig.pesan_ditolak;
            }
        }        
        Console.WriteLine(pesan_keluar);

        Console.WriteLine("\n\n");
        Console.WriteLine("---========Mengubah satuan ke fahhrenheit======---");
        Console.WriteLine("\n\n");

        covig.UbahSatuan();
        Console.Write("Berapa suhu badan anda saat ini?" +
            " Dalam nilai " + covig.konfig.satuan_suhu + " ");
        suhu_sekarang = Convert.ToDouble(Console.ReadLine());
        Console.Write("Berapa hari yang lalu (perkiraan) " +
            "anda terakhir memiliki gejala demam? ");
        gejala_demam = Convert.ToInt32(Console.ReadLine());
        pesan_keluar = covig.konfig.pesan_ditolak;
        if (gejala_demam > covig.konfig.batas_hari_demam)
        {
            if (covig.konfig.satuan_suhu == "celcius")
            {
                pesan_keluar = (suhu_sekarang >= 36.5 && suhu_sekarang <= 37.5) ?
                    covig.konfig.pesan_diterima : covig.konfig.pesan_ditolak;
            }
            else if (covig.konfig.satuan_suhu == "fahrenheit")
            {
                pesan_keluar = (suhu_sekarang >= 97.7 && suhu_sekarang <= 99.5) ?
                    covig.konfig.pesan_diterima : covig.konfig.pesan_ditolak;
            }
        }
        Console.WriteLine(pesan_keluar);
    }
}

