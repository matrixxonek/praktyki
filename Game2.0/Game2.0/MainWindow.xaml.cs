using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game2._0
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player gracz = new Player(mainAttack, fireball, stoneThrow);
        Enemy enemy = new Enemy(mainAttack, electro, pan);
        public static Spell mainAttack = new Spell(15, 50);
        public static Spell fireball = new Spell(35, 150);
        public static Spell stoneThrow = new Spell(5, 0);
        public static Spell electro = new Spell(40, 150);                         //deklaracja zmiennych
        public static Spell pan = new Spell(5, 0);
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }
        public void StartGame()
        {
            gracz.setPlayerName("Jan");
            playerNameShow.Text = gracz.playerName;
            enemyNameShow.Text = enemy.enemyName;
            playerHpBar.Maximum = gracz.playerHp;
            playerManaBar.Maximum = gracz.playerMana;
            enemyHpBar.Maximum = enemy.enemyHp;                                        //początek gry, bary
            enemyManaBar.Maximum = enemy.enemyMana;
            playerHpBar.Value = gracz.playerHp;
            playerManaBar.Value = gracz.playerMana;
            enemyHpBar.Value = enemy.enemyHp;
            enemyManaBar.Value = enemy.enemyMana;
        }
        public void Attack()
        {
            int attackSelected = attackType.SelectedIndex;
            if (attackSelected == 0)
            {
                if (CanUse(gracz.playerMana, gracz.mySpells[0].spellMana))
                {
                    gracz.setPlayerDmg(gracz.mySpells[0].spellDmg);
                    gracz.playerManaChange(gracz.playerMana, gracz.mySpells[0].spellMana);
                    gracz.usedSpell = true;
                    playerText.Text = "Atak podstawowy! Obrażenia: " + gracz.mySpells[0].spellDmg;
                    enemy.enemyHp = enemy.enemyHp - gracz.playerDmg;
                }
                else
                {                                                                               //atak gracza
                    playerText.Text = "Zbyt mało many, użyj innej umiejętności!";
                }
            }
            else if (attackSelected == 1)
            {
                if (CanUse(gracz.playerMana, gracz.mySpells[1].spellMana))
                {
                    gracz.setPlayerDmg(gracz.mySpells[1].spellDmg);
                    gracz.playerManaChange(gracz.playerMana, gracz.mySpells[1].spellMana);
                    gracz.usedSpell = true;
                    playerText.Text = "Kula ognia! Obrażenia: " + gracz.mySpells[1].spellDmg;
                    enemy.enemyHp = enemy.enemyHp - gracz.playerDmg;
                }
                else
                {
                    playerText.Text = "Zbyt mało many, użyj innej umiejętności!";
                }
            }
            else if (attackSelected == 2)
            {
                gracz.setPlayerDmg(gracz.mySpells[2].spellDmg);
                gracz.playerManaChange(gracz.playerMana, gracz.mySpells[2].spellMana);
                gracz.usedSpell = true;
                playerText.Text = "Rzut kamieniem! Obrażenia: " + gracz.mySpells[2].spellDmg;
                enemy.enemyHp = enemy.enemyHp - gracz.playerDmg;
            }
        }
        private void EnemyAttack()
        {
            enemy.usedSpell = false;
            int enemyAttack = 0;

            while (enemy.usedSpell == false)
            {
                enemyAttack = r.Next(enemy.mySpells.Count) + 1;
                if (enemyAttack == 1)
                {
                    if (CanUse(enemy.enemyMana, enemy.mySpells[0].spellMana))
                    {
                        enemy.setEnemyDmg(enemy.mySpells[0].spellDmg);
                        enemy.enemyManaChange(enemy.enemyMana, enemy.mySpells[0].spellMana);
                        enemy.usedSpell = true;
                        enemyText.Text = "Atak podstawowy! Obrażenia: " + enemy.mySpells[0].spellDmg;
                        break;
                    }
                    else
                    {
                        continue;                                                               //atak przeciwnika
                    }
                }
                else if (enemyAttack == 2)
                {
                    if (CanUse(enemy.enemyMana, enemy.mySpells[1].spellMana))
                    {
                        enemy.setEnemyDmg(enemy.mySpells[1].spellDmg);
                        enemy.enemyManaChange(enemy.enemyMana, enemy.mySpells[1].spellMana);
                        enemy.usedSpell = true;
                        enemyText.Text = "Elektryczne pioruny! Obrażenia: " + enemy.mySpells[1].spellDmg;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (enemyAttack == 3)
                {
                    enemy.setEnemyDmg(enemy.mySpells[2].spellDmg);
                    enemy.enemyManaChange(enemy.enemyMana, enemy.mySpells[2].spellMana);
                    enemy.usedSpell = true;
                    enemyText.Text = "Cios patelnią! Obrażenia: " + enemy.mySpells[2].spellDmg;
                    break;
                }
            }
            Console.WriteLine("Przeciwnik zaatakował " + enemyAttack);
            gracz.playerHp -= enemy.enemyDmg;
        }
        private bool CanUse(int objectMana, int manaNeed)
        {
            if (objectMana < manaNeed)
                return false;                           //metoda sprawdza, czy masz wystarczająco many, by użyć tej umiejętności
            else
                return true;
        }

        private void attackButton_Click(object sender, RoutedEventArgs e)
        {
            gracz.usedSpell = false;
            enemy.usedSpell = false;
            if(gracz.usedSpell == false)
            {
                Attack();
            }
            else
            gracz.usedSpell = false;                        //wykonanie ataków i sprawdzenie, czy gra nie powinna zostać zakończona
            EndCheck();
            if(enemy.usedSpell == false && gracz.usedSpell == true)
            {
                EnemyAttack();
                enemy.usedSpell = true;
            }
            else
            enemy.usedSpell = false;
            EndCheck();
            StatsShow();
            BarUpdate();
        }

        private void BarUpdate()
        {
            playerHpBar.Value = gracz.playerHp;
            playerManaBar.Value = gracz.playerMana;
            enemyHpBar.Value = enemy.enemyHp;
            enemyManaBar.Value = enemy.enemyMana;
        }

        private void StatsShow()
        {
            playerHpShow.Text = "Zdrowie: " + gracz.playerHp;                      //metoda zmienia staty
            playerManaShow.Text = "Mana: " + gracz.playerMana;
            enemyHpShow.Text = "Zdrowie: " + enemy.enemyHp;
            enemyManaShow.Text = "Mana: " + enemy.enemyMana;
        }

        private void EndCheck()
        {
            bool playerDead = false;
            bool enemyDead = false;

            if (gracz.playerHp <= 0)
                playerDead = true;
            if (enemy.enemyHp <= 0)               //metoda sprawdzająca, czy gra nie powinna się skończyć (wstępnie, nie przerywa gry)
                enemyDead = true;

            if(playerDead && enemyDead)
            {
                Console.WriteLine("koniec gry");
                drawText.Visibility = Visibility.Visible;
                winText.Visibility = Visibility.Hidden;
                defeatText.Visibility = Visibility.Hidden;
            } else if(enemyDead == true)
            {
                winText.Visibility = Visibility.Visible;
            }else if(playerDead == true)
            {
                defeatText.Visibility = Visibility.Visible;
            }
        }
    }

    public class Player
    {
        public string playerName;
        public int playerHp = 100;
        public int playerMana = 300;
        public int playerDmg;
        public bool usedSpell = false;                            //klasa gracza
        public List<Spell> mySpells = new List<Spell>();
        public void setPlayerName(string name)
        {
           playerName = name;
        }
        public void setPlayerDmg(int dmg)
        {
            playerDmg = dmg;
        }
        public void playerManaChange(int mana, int manaUse)
        {
            playerMana = mana - manaUse;
        }
        public void setSpells(Spell s1, Spell s2, Spell s3)
        {
            mySpells.Add(s1);
            mySpells.Add(s2);
            mySpells.Add(s3);
        }
        public Player(Spell s1, Spell s2, Spell s3)
        {
            setSpells(s1, s2, s3);
        }
    }

    public class Enemy
    {
        public string enemyName = "bufor";
        public int enemyHp = 100;
        public int enemyMana = 300;
        public int enemyDmg;
        public bool usedSpell = false;
       // public Spell[] mySpellss = new Spell[3];
        public List<Spell> mySpells = new List<Spell>();
        public void setEnemyDmg(int dmg)                                //klasa przeciwnika
        {
            enemyDmg = dmg;
        }
        public void enemyManaChange(int mana, int manaUse)
        {
            enemyMana = mana - manaUse;
        }
        public void setSpells(Spell s1, Spell s2, Spell s3)
        {
            mySpells.Add(s1);
            mySpells.Add(s2);
            mySpells.Add(s3);
        }
        public Enemy(Spell s1, Spell s2, Spell s3)
        {
            setSpells(s1, s2, s3);
        }
    }
    public class Spell
    {
        public int spellDmg;
        public int spellMana;

        public Spell(int dmg, int mana)                         //klasa dla umiejętności
        {
            spellDmg = dmg;
            spellMana = mana;
        }
    }
}
