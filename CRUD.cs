using System;
using System.Collections.Generic;

namespace Program{
	class main{

		// this is an attribute class
		public static List<string> list = new List<string>();

		public static void Main(string[] args){
			while (true){
				Console.WriteLine("selecione uma opção: add, rem, edit, ver, sair");

				string response = Console.ReadLine().Trim();

				switch (response){
					case "add":
						add();
						break;

					case "ver":
						viewList();
						break;

					case "edit":
						edit();
						break;

					case "rem":
						remove();
						break;

					case "sair":
						Console.WriteLine("saindo...");
						return;

					default:
						Console.WriteLine("default");
						break;
				}

			}

		}

		public static bool verifyLengthOfList(){
			if (list.Count < 1){
				return false;
			}
			return true;
		}

		public static bool verifyItemInList(string item){
			if (list.Contains(item)){
				Console.WriteLine("Já existe esse item");
				return false;
			}
			return true;
		}

		public static void add(){
			Console.Clear();
			Console.WriteLine("Digite o que voce quer adicionar na lista");

			// trim its like strip in python;
			string item = Console.ReadLine().Trim(); 

			if (!verifyItemInList(item)){
				return;
			}

			list.Add(item);
			Console.WriteLine($"item '{item}' adicionado com sucesso");
		}

		public static void viewList(string customText = null){
			Console.Clear();
			if (!verifyLengthOfList()){
				Console.WriteLine("Lista vazia.");
				return;
			}

			if (customText == null){
				customText = "Lista completa:";
			}

			Console.WriteLine(customText);
			for (int i = 0; i < list.Count; i++){
				Console.WriteLine($"indice: {i + 1} | {list[i]}");
			}
		}

		public static void edit(){
			Console.Clear();
			if (!verifyLengthOfList()){
				Console.WriteLine("Lista vazia.");
				return;
			}
			viewList();

			Console.WriteLine("Digite o numero do indice da lista que quer alterar");
			string indexInput = Console.ReadLine();
			int index;

			if (int.TryParse(indexInput, out index)){

				int listIndex = index - 1;
				Console.WriteLine("Digite o item que quer colocar: ");
				string item = Console.ReadLine().Trim();  

				list[listIndex] = item;  

				viewList("Lista atualizada:");

				return;
			}
			throw new Exception($"{indexInput} is NaN");
		}

		public static void remove(){
			Console.Clear();
			if (!verifyLengthOfList()){
				Console.WriteLine("Lista vazia.");
				return;
			}
			viewList();


			Console.WriteLine("Digite o indice da lista que voce quer excluir");
			string indexInput = Console.ReadLine();
			int index;


			if (int.TryParse(indexInput, out index)){
				int listIndex = index - 1;

				list.RemoveAt(listIndex);

				viewList("Lista atualizada:");

				return;
			}
			Console.WriteLine("Índice inválido");
			return;
		}
	}
}
