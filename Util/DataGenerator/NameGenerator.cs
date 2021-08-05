using System;
using System.Collections.Generic;

namespace Super.GlobalPlatform.Regression.Api.Util.DataGenerator
{
    public static class NameGenerator
    {
        public static string FullName()
        {
            Random rdn = new Random();

            List<string> firstName = new List<string>
            {
                "Agda", "Andreia", "Andre", "Adriano", "A   binadar", "Alice", "Ariana", "Alencar", "Alcemir", "Aline", "Americo","Ariane", "Bruno", "Bruna","Beatriz", "Berenice", "Benedito", "Benedita", "Carlos", "Camila", "Caroline","Camilo", "Ceverino", "Denis", "Denise","Daniel", "Dorivaldo", "Darley", "Edson", "Eliane","Eliana", "Ester", "Everaldo", "Elias", "Estenio", "Etevaldo", "Euclides", "Eliezer", "Everaldo", "Eduardo", "Emanuel", "Eunice", "Elaine", "Jaqueline", "Josivaldo", "josefina", "Larissa","Lais", "Laercio", "Leandro", "Lucas", "Maria", "Marcos", "Melissa", "Marcelo", "Mariana", "Matheus","Milena", "Neilson", "Naiara", "Nilson", "Nerivaldo", "Noemia","Nubia", "Nilvan", "Olavo", "Oliver","Olindo", "Paulo", "Paula", "Pedro", "Pedrina", "Pivanne", "Patricia", "Quelvin", "Queila", "Ronaldo","Ronan", "Romildo", "Rodolfo", "Rita", "Ravier", "Roma", "Salivan", "Selton", "Simira", "Tadeu","Tais","Tamila", "Tadeu", "Telma", "Ulisson", "Umberto", "Vicente", "Vanice", "Vera", "Valdermor", "Zulmira","Zenira"
            };

            List<string> lastName = new List<string>
            {
                "Andrade Barbosa", "Barbosa Oliveira", "Oliveira da Silva", "Alves Pereira","Conceicao Barbosa", "Allen Young", "Hernandez King" , "Wright Lopez" , "Hill Scott", "Green Adams","Conceicao da Costa", "da Costa Oliveira", "Rodrigues de Oliveira", "Amaral Neto de Souza", "Pereira da Conceicao", "Barros Neto de Andrade", "Borges de Andrade Pereira da Silva", "Batista Campos do Amaral","Cardoso de Oliveira", "Pontes Guimaraes", "Dias de Jesus", "Barbos de Lima", "Goncalves da Silva", "Gonsalves de Lima", "Pereira de Oliveira Batista", "Dias de Freitas", "Ferreira", "Garcia da Paixao", "Lima Lopes", "Jesus da Silva", "da Silva de Lima", "da Silva Gonsalves Texeira", "Fernandes de Paula", "de Paula da Silva", "Barbosa de Mello Oliveira", "Oliveira Neto Conceicao da Paixao"
            };

            return $"{firstName[rdn.Next(firstName.Count)]}  {lastName[rdn.Next(lastName.Count)]}";
        }
    }
}
