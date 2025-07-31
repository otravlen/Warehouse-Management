namespace Backend.Database_Layer
{
	public class Entities
	{
		public class Resource
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public bool IsArchived { get; set; }
			public int UnitOfMeasureId { get; set; }
			public UnitOfMeasure UnitOfMeasure { get; set; }
		}

		// Единица измерения
		public class UnitOfMeasure
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public bool IsArchived { get; set; }
		}

		// Клиент
		public class Client
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string Address { get; set; }
			public bool IsArchived { get; set; }
		}

		// Баланс
		public class StockBalance
		{
			public int Id { get; set; }
			public int ResourceId { get; set; }
			public Resource Resource { get; set; }
			public int UnitOfMeasureId { get; set; }
			public UnitOfMeasure UnitOfMeasure { get; set; }
			public decimal Quantity { get; set; }
		}

		// Документ поступления
		public class IncomeDocument
		{
			public int Id { get; set; }
			public string Number { get; set; }
			public DateTime Date { get; set; }
			public List<IncomeDocumentItem> Items { get; set; } = new();
		}

		// Ресурс поступления
		public class IncomeDocumentItem
		{
			public int Id { get; set; }
			public int IncomeDocumentId { get; set; }
			public IncomeDocument IncomeDocument { get; set; }
			public int ResourceId { get; set; }
			public Resource Resource { get; set; }
			public int UnitOfMeasureId { get; set; }
			public UnitOfMeasure UnitOfMeasure { get; set; }
			public decimal Quantity { get; set; }
		}

		// Документ отгрузки
		public class OutcomeDocument
		{
			public int Id { get; set; }
			public string Number { get; set; }
			public int ClientId { get; set; }
			public Client Client { get; set; }
			public DateTime Date { get; set; }
			public bool IsCompleted { get; set; }
			public List<OutcomeDocumentItem> Items { get; set; } = new();
		}

		// Ресурс отгрузки
		public class OutcomeDocumentItem
		{
			public int Id { get; set; }
			public int OutcomeDocumentId { get; set; }
			public OutcomeDocument OutcomeDocument { get; set; }
			public int ResourceId { get; set; }
			public Resource Resource { get; set; }
			public int UnitOfMeasureId { get; set; }
			public UnitOfMeasure UnitOfMeasure { get; set; }
			public decimal Quantity { get; set; }
		}
	}
}
