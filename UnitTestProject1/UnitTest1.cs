using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using WpfApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class XorCipherTests
    {
        [TestMethod]
        public void XorEncryptDecrypt_String_RestoresOriginalText()
        {
            string original = "Привет, XOR! 123";
            string key = "secret";

            string encrypted = XOR.XorEncrypt(original, key);
            string decrypted = XOR.XorDecrypt(encrypted, key);

            Assert.AreEqual(original, decrypted);
            Assert.AreNotEqual(original, encrypted);
        }

        [TestMethod]
        public void XorEncryptDecrypt_ByteArray_RestoresOriginalData()
        {
            byte[] original = Encoding.UTF8.GetBytes("Binary data: 你好, мир, hello");
            byte[] key = Encoding.UTF8.GetBytes("key");

            byte[] encrypted = XOR.XorEncrypt(original, key);
            byte[] decrypted = XOR.XorEncrypt(encrypted, key);

            CollectionAssert.AreEqual(original, decrypted);
        }

        [TestMethod]
        public void XorEncrypt_String_WithLongKey_WorksCorrectly()
        {
            string original = "Short text";
            string key = "ThisIsAVeryLongKeyThatRepeatsIfNeeded";

            string encrypted = XOR.XorEncrypt(original, key);
            string decrypted = XOR.XorDecrypt(encrypted, key);

            Assert.AreEqual(original, decrypted);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void XorEncrypt_String_NullText_Throws()
        {
            XOR.XorEncrypt(null, "key");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void XorEncrypt_String_EmptyKey_Throws()
        {
            XOR.XorEncrypt("text", "");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void XorDecrypt_InvalidBase64_Throws()
        {
            XOR.XorDecrypt("not_base64!!!", "key");
        }
    }
}
