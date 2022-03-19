namespace OH.DI.Web.Endpoints.DigitalCredentialEndpoints;

public class UpdateDigitalCredentialResponse
{
  public UpdateDigitalCredentialResponse(DigitalCredentialRecord DigitalCredential)
  {
    DigitalCredential = DigitalCredential;
  }
  public DigitalCredentialRecord DigitalCredential { get; set; }
}
