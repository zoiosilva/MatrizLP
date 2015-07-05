using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrizLPWinForms
{
    public partial class frmCalculo : Form
    {
        public frmCalculo()
        {
            InitializeComponent();
        }

        private void nudOrdem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnCalcular_Click(sender, e);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnCalcular.Text = "Calculando...";
            btnCalcular.Refresh();
            var tempoInicial = DateTime.Now;
            Calcular(Convert.ToInt32(nudOrdem.Value));
            lblResposta.Text = DateTime.Now.Subtract(tempoInicial).TotalSeconds.ToString("N4") + " Segundos.";
            btnCalcular.Text = "Calcular";
            Cursor = Cursors.Default;
        }

        private void Calcular(int ordem)
        {
            var matriz = new int[ordem, ordem];
            var rand = new Random();
            Parallel.For(0, ordem, i =>
                {
                    Parallel.For(0, ordem, j =>
                        {
                            matriz[i, j] = rand.Next();
                        });
                });

            detLP(matriz, ordem);
        }

        /// <summary>
        /// Calcula a Determinante da Matriz pelo teorema de LaPLace.
        /// </summary>
        /// <param name="mat">Matriz.</param>
        /// <param name="Max">Máximo.</param>
        /// <returns>A determinante.</returns>
        private static double detLP(int[,] mat, int Max)
        {
            if (Max <= 3)
                return (det3x3(mat, Max)); //Se a Matriz for de ordem 3, já calcula a Determinante
            else // Se a ordem dela for maior do que 3, aí o bicho pega...
            {
                var matriz = new int[Max, Max];
                var cofs = new double[Max];

                var j2 = 0;
                var cof = 0;
                var determinanteFinal = 0d;

                while (cof < Max)// Enquanto a Ordem > 3 e ainda houver cofatores para calcular
                {
                    int i2 = 0;
                    //Parallel.For(0, Max, i1 =>
                    //{
                        for (int i1 = 0; i1 <= (Max - 1); i1++) // Atribui os valores na matriz para multiplicar pelo cofator
                        {
                            if (i1 != 0) // Eu escolhi pegar os cofatoes da linha 0 da matriz
                            {
                                //Parallel.For(0, Max, j1 =>
                                for (int j1 = 0; j1 <= (Max - 1); j1++)
                                {
                                    if (j1 != cof)  //j é linha e i é coluna
                                    {
                                        matriz[i2, j2] = mat[i1, j1]; // Bem, aqui é assim: tenho que fazer uma matriz de ordem menor, excluindo
                                        j2++;						  // a linha e a coluna do cofator e copiando os outros elementos. Capitche?
                                    }
                                }//);
                                i2++;
                            }
                            j2 = 0;
                        }
                    //});                    

                    cofs[cof] = mat[0, cof] * Math.Pow(-1d, cof + 2d) * detLP(matriz, (Max - 1)); //Teorema de LaPlace part 1; A recursividade é o segredo para se calcular uma matriz de qualquer ordem
                    cof++; // cofator
                }
                Parallel.For(0, Max, i => determinanteFinal += cofs[i]); //Teorema de LaPlace part 2: somando os cofatores

                return determinanteFinal;
            }
        }

        /// <summary>
        /// Determinante da Matriz 3x3, 2x2 e 1x1.
        /// </summary>
        /// <param name="matriz">Matriz.</param>
        /// <param name="ordem">Ordem.</param>
        /// <returns>A Determinante.</returns>
        private static int det3x3(int[,] matriz, int ordem)
        {
            switch (ordem)
            {
                case 0:
                    return 0;

                case 1:
                    return (matriz[0, 0]);

                case 2:
                    return ((matriz[0, 0] * matriz[1, 1]) - (matriz[1, 0] * matriz[0, 1]));

                default:
                    var dp = new int[ordem];
                    var ds = new int[ordem];
                    var indice = 1;

                    Parallel.For(0, ordem, i =>
                        {
                            dp[i] = 1;
                            ds[i] = 1;
                        });

                    for (int j = 0; j < ordem; j++) // Diagonal Principal
                    {
                        indice--;
                        for (int i = 0; i < ordem; i++) // Segredo: um índice (in) que fica variando, por exemplo, entre 0, 1, 2, 0, 1, 2...
                        {
                            if (indice == -1) indice = ordem - 1; // Aqui o algoritmo vai simplesmente multiplicar os
                            if (indice == ordem) indice = 0;   // elementos da matriz, e depois armazená-los nesse
                            dp[j] *= matriz[i, indice];   // vetor. Depois eu somo os elementos do vetor.
                            indice++;
                        }
                        indice--;
                    }

                    indice = 1; // Fique esperto com esse 'indice', porque aqui que está o segredo de tudo.
                    for (int j = 0; j < ordem; j++) // Diagonal Secundária
                    {
                        indice--;
                        for (int i = ordem - 1; i >= 0; i--) // Segredo: um índice (in) que fica variando, por exemplo, entre 2, 1, 0, 2, 1, 0...
                        {
                            if (indice == -1) indice = ordem - 1; // Mesma coisa que a Diagonal Principal, só que
                            if (indice == ordem) indice = 0;   // seguindo a Diagonal Secundária da matriz
                            ds[j] *= matriz[i, indice];
                            indice++;
                        }
                        indice--;
                    }

                    var resDP = 0;
                    var resDS = 0;

                    Parallel.For(0, ordem, i =>
                    {
                        resDP += dp[i]; // Agora eu somo as multiplicações das diagonais
                        resDS += ds[i]; // e armazeno-as nessas variáveis aí
                    });

                    return resDP - resDS; // Tiro uma da outra e... cabô!
            }
        }
    }
}