using System;
using System.IO;
using System.Reflection;

namespace Public_Private_Key_Encryptor
{
    class Example
    {
        static void Main(string[] args)
        {
            string private_key = "<RSAKeyValue><Modulus>VsABn18QLT9ee3x5Mk8RCqNIaFFUu1watVI0HLz5kF0vi0jomGWXTLX55tDfSJTHqMTA339R+9XcOSTnXHX1NQ==</Modulus><Exponent>AQAB</Exponent><P>l86VkmzzW+BjWx5LPZ45a/MdLraZnRgSpIpJf7LHnyE=</P><Q>kkqEjdWnKUGIieJOJoEXDPgdu7NFn6elUcEmcl+Od5U=</Q><DP>czvp5iC2CsQmJ4CzdK6qv/rn6BHMQaeIX0ZpzHmVdoE=</DP><DQ>aytyHiH1+vBKYZDLZcPOKi8eQSKdD9AV+WWBj+pXCV0=</DQ><InverseQ>QyTluXg8PtDmo1BbkpPPX0a2WpRhUbHimHUMQrMfUfE=</InverseQ><D>Ozeso98fytNkKsWIcgg5KNrXdaZ3QcKY1Me9nRR/A8VdTlmTFcWerCjwZUrgPwZK/eWWyQqzFCuQpliNzMC+gQ==</D></RSAKeyValue>";
            string public_key = "<RSAKeyValue><Modulus>VsABn18QLT9ee3x5Mk8RCqNIaFFUu1watVI0HLz5kF0vi0jomGWXTLX55tDfSJTHqMTA339R+9XcOSTnXHX1NQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";


            RSAController rsa = new RSAController(private_key, public_key); // The RSAController needs the private and public Key

            Console.WriteLine("Enter The Password: ");

            string Password = Console.ReadLine();

            string Password_Encrypded = rsa.Encrypt(Password); //Encrypt the Password

            string m_exePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\Password_Encrypted.txt"))
                {
                    w.WriteLine(Password_Encrypded);
                }
            }
            catch (Exception)
            {
            }


        }
    }
}
