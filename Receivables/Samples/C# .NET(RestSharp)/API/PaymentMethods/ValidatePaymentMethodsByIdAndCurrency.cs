/// <summary>
/// API Request to validate the payment method is associated to the currency on PayFabric Receivables
/// </summary>
/// <param name="URL">URL of the PayFabric Receivables site</param>
/// <param name="walletId">WalletId object to get</param>
/// <param name="currencyCode">Currency code object to get</param>
/// <param name="token">PayFabric Receivables token object</param>
/// <param name="paymentMethods">Returned payment method object</param>
public void GetPaymentMethodByIdAndCurrency(string URL, string walletId, string currencyCode, Token token, ref PaymentMethodResponse paymentMethod)
{
	// Sample request and response
	// ------------------------------------------------------
	// Go to https://github.com/PayFabric/APIs/blob/master/Receivables/Sections/APIs/API/PaymentMethods.md#retrieve-a-payment-method-and-verify-currency for more details about request and response.
	// Go to https://github.com/PayFabric/APIs/blob/master/Receivables/Sections/Objects/PaymentMethod.md#PaymentMethodResponse for more details about the object.
	// ------------------------------------------------------
	
	var client = new RestClient(URL + "API/paymentmethods/" + walletId + "/valid?currencyCode=" + currencyCode);
	var request = new RestRequest(Method.GET);
	request.AddHeader("content-type", "application/json");
	request.AddHeader("authorization", "Bearer " + token.access_token);
	IRestResponse response = client.Execute(request);

	if (response.StatusCode == System.Net.HttpStatusCode.OK)
	{
		try
		{
			JsonDeserializer deserial = new JsonDeserializer();
			paymentMethod = deserial.Deserialize<PaymentMethodResponse>(response);
		}
		catch
		{
			paymentMethod = null;
		}
	}
	else
		paymentMethod = null;
}
