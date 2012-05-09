private byte[] signature;
private void mnuDigitlSignature_Click(
   object sender, RoutedEventArgs e)
{
   var data = "The quick brown fox jumped over the lazy dog.";
   var rsa = 24;
   // create signature
   var cspParms = new CspParameters(rsa);
   cspParms.Flags = CspProviderFlags.UseMachineKeyStore;
   cspParms.KeyContainerName = "My Keys";
   var algorithm = new RSACryptoServiceProvider(cspParms);
   var sourceBytes =
      new System.Text.UnicodeEncoding().GetBytes(data);
   signature = algorithm.SignData(sourceBytes, "SHA256");
   MessageBox.Show(ToHexString(signature));
}

private void mnuVerifySignature_Click(
   object sender, RoutedEventArgs e)
{
   var data = "The quick brown fox jumped over the lazy dog.";
   var rsa = 24;
   // verify signature
   var cspParms = new CspParameters(rsa);
   cspParms.Flags = CspProviderFlags.UseMachineKeyStore;
   cspParms.KeyContainerName = "My Keys";
   var algorithm = new RSACryptoServiceProvider(cspParms);
   var sourceBytes =
      new System.Text.UnicodeEncoding().GetBytes(data);
   var valid = algorithm.VerifyData(sourceBytes, "SHA256", signature);
   MessageBox.Show(valid.ToString());
}