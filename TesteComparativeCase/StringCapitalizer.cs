using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using Xunit;

namespace TesteComparativeCase
{
    public class StringCapitalizer
    {
        private Dictionary<string, string> excecoes = new Dictionary<string, string>()
            {
                { "Do", "do" },
                { "Da", "da" },
                { "De", "de" },
                { "Das", "das" },
                { "Dos", "dos" },
                { "E", "e" },               
            };
                
        public string capitalize(string str)
        {
            str = str.ToLower();

            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            var stringCapitalizada = textInfo.ToTitleCase(str);

            var sb = new StringBuilder(stringCapitalizada, stringCapitalizada.Length * 2);

            StringBuilderReplace2(sb);

            return sb.ToString();
        }

        private void StringBuilderReplace2(StringBuilder data)
        {
            foreach (string k in excecoes.Keys)
            {
                data.Replace(k, excecoes[k]);
            }
        }

        [Fact]
        public void StringTodaEmCaixaBaixa()
        {
            string nome = "aura maria guimarães do nascimento";
            string nomeCapitalizado = capitalize(nome);
            Assert.True(nomeCapitalizado == "Aura Maria Guimarães do Nascimento");
        }

        [Fact]
        public void teste()
        {
            string nome = "ONU";
            string nomeCapitalizado = capitalize(nome);
            Assert.True(nomeCapitalizado == "Onu");
        }

        [Fact]
        public void StringTodaEmCaixaAlta()
        {
            string nome = "AURA MARIA GUIMARÃES DO NASCIMENTO";
            string nomeCapitalizado = capitalize(nome);
            Assert.True(nomeCapitalizado == "Aura Maria Guimarães do Nascimento");
        }

        [Fact]
        public void TestaExcecoes()
        {
            string nome = "AURA maria DE GuIMARÃES dOs NAscIMENTO dA silva E souza";
            string nomeCapitalizado = capitalize(nome);
            Assert.True(nomeCapitalizado == "Aura Maria de Guimarães dos Nascimento da Silva e Souza");
        }

        [Fact]
        public void TestaExcecoes2()
        {
            string nome = "AURA maria DE GuIMARÃES dOs NAscIMENTO dA silva E souza";
            string nomeCapitalizado = capitalize(nome);
            Assert.False(nomeCapitalizado == "Aura Maria de Guimarães dos Nascimento da silva e Souza");
        }
    }
}
