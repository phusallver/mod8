using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace mod8
{
    internal class CovidConfig
    {
        public Konfig konfig;
        private const string filepath = @"covid_config.json";

        public CovidConfig()
        {
            try
            {
                ReadKonfigFile();
            }
            catch
            {
                SetDefault();
                WriteKonfigFile();
            }
        }
        public void ReadKonfigFile()
        {
            string hasilBaca = File.ReadAllText(filepath);
            konfig = JsonSerializer.Deserialize<Konfig>(hasilBaca);
        }
        public void WriteKonfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string tulisan = JsonSerializer.Serialize(konfig, options);
            File.WriteAllText(filepath, tulisan);
        }
        public void SetDefault()
        {
            konfig = new Konfig();
            konfig.satuan_suhu = "celcius";
            konfig.batas_hari_demam = 14;
            konfig.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            konfig.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }
        public void UbahSatuan()
        {
            konfig.satuan_suhu = (konfig.satuan_suhu == "celcius") ?
                "fahrenheit" : "celcius";
            WriteKonfigFile();
        }
    }
}
public class Konfig
{
    public string satuan_suhu { get; set; }
    public int batas_hari_demam { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }
    public Konfig() { }
}
