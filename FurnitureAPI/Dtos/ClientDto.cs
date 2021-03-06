namespace FurnitureAPI.Dtos
{
  public class ClientDto
  {
    public int ClientId { get; set; }
    public string ClientName { get; set; }
    public string ClientSurname { get; set; }
    public string ClientPesel { get; set; }
    public string ClientPhone { get; set; }
    public string ClientEmail { get; set; }
    public string ClientTown { get; set; }
    public string ClientStreet { get; set; }
    public string ClientNumberHome { get; set; }
    public string ClientPostPlace { get; set; }
    public string ClientPostalCode { get; set; }
    public string ClientInterested { get; set; }

    public string GetExportObject()
    {
      return $"{ClientId};{ClientName};{ClientSurname};{ClientPesel};{ClientPhone};{ClientEmail};{ClientTown};{ClientStreet};{ClientNumberHome};{ClientPostPlace};{ClientPostalCode};{ClientInterested};";
    }
  }
}