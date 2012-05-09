private byte[] rsaCipherText;
private void mnuAsymmetricEncryption_Click(
   object sender, RoutedEventArgs e)
{
   var rsa = 1;
   // Encrypt the data.
   var cspParms = new CspParameters(rsa);
   cspParms.Flags = CspProviderFlags.UseMachineKeyStore;
   cspParms.KeyContainerName = "My Keys";
var algorithm = new RSACryptoServiceProvider(cspParms);
   var sourceBytes = new UnicodeEncoding().GetBytes(myData);
   rsaCipherText = algorithm.Encrypt(sourceBytes, true);
   MessageBox.Show(String.Format(
      "Data: {0}{1}Encrypted and Encoded: {2}",
      myData, Environment.NewLine,
      Convert.ToBase64String(rsaCipherText)));
}


private void mnuAsymmetricDecryption_Click(
   object sender, RoutedEventArgs e)
{
   if(rsaCipherText==null)
   {
      MessageBox.Show("Encrypt First!");
      return;
   }
   var rsa = 1;
   // decrypt the data.
   var cspParms = new CspParameters(rsa);
   cspParms.Flags = CspProviderFlags.UseMachineKeyStore;
   cspParms.KeyContainerName = "My Keys";
   var algorithm = new RSACryptoServiceProvider(cspParms);
   var unencrypted = algorithm.Decrypt(rsaCipherText, true);
   MessageBox.Show(new UnicodeEncoding().GetString(unencrypted));
}