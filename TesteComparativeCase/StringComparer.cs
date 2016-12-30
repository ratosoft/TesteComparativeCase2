using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteComparativeCase
{
    public class StringComparer
    {        
        public bool compara2strings(string s1, string s2)
        {
            s1 = s1.Replace("'", " ").ToUpper();
            s2 = s2.Replace("'", " ").ToUpper();
            return string.Compare(s1, s2, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0;
        }

        [Fact]
        public void teste1()
        {
            Assert.True(compara2strings("CAÇÃO", "CACAO"));
        }

        [Fact]
        public void DeveIgnorarIndependenteMaiusculoMinusculo()
        {
            Assert.True(compara2strings("cação", "CACAO"));
        }

        [Fact]
        public void DeveIgnorarTil()
        {
            Assert.True(compara2strings("cação", "cacão"));
        }

        [Fact]
        public void DeveIgnorarAgudo()
        {
            Assert.True(compara2strings("café", "CAFE"));
        }

        [Fact]
        public void teste5()
        {
            Assert.True(compara2strings("cafe", "CAFE"));            
        }

        [Fact]
        public void DeveIgnorarCircunflexo()
        {
            Assert.True(compara2strings("econômico", "ECONÓMICO"));            
        }

        [Fact]
        public void DeveIgnorarCircunflexo2()
        {
            Assert.True(compara2strings("ecOnômico", "EcONOMiCO"));
        }

        [Fact]
        public void DeveIgnorarCedilha()
        {
            Assert.True(compara2strings("piraqueacu", "piraqueaÇú"));
        }

        [Fact]
        public void DeveIgnorarTremas()
        {
            Assert.True(compara2strings("conseqüente", "consequente"));
            
        }

        [Fact]
        public void DeveSubstituirApostrofoPorEspaco()
        {
            Assert.True(compara2strings("d'ornelas", "d ornelas"));
        }

        [Fact]
        public void DeveIgnorarAcentoGrave()
        {
            Assert.True(compara2strings("às vezes", "as vezeS"));
        }
    }
}
