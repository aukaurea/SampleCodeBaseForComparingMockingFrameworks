using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;

namespace SampleCodeBase
{
    public class TryCatchThrowExample
    {
        private string _stringProperty1;

        public string StringProperty1
        {
            get => _stringProperty1;
            set
            {
                _stringProperty1 = value;
                throw new Exception("");
            }
        }

        private string PrivateStringProperty1 { get; set; }
        private static string PrivateStaticStringProperty1 { get; set; }
        private DateTime PrivateDateTimeProperty1 { get; set; }
        private List<DateTime> PrivateListDateTimeProperty1 { get; set; }

        private void MethodThrows(Exception ex)
        {
            throw ex;
        }

        private void MethodThrows()
        {
            throw new ArgumentException();
        }

        public void TryCatchWithThrowExample(string p1, string p2)
        {
            // don't detect this.
            // if visited no worries
            if (p2 == null && p1 == PrivateStringProperty1 || PrivateDateTimeProperty1.Equals(null))
            {
                // if visited no worries
            }
            else
            {
                // if visited no worries
                // else part
            }

            try
            {
                //do stuff
                var x = PrivateStaticStringProperty1;
                var y = x + "";

                // Compute in such a way so that it doesn't get visited or by pass or if visited then code much reach to the end of try block.
                if (ReturnsAndThrowsFalse() || DatabaseCallPauseFor30SecondsAndThrowsReturnsTrue() && p2 == null && p1 == PrivateStringProperty1 || PrivateDateTimeProperty1.Equals(null))
                {
                    // don't need to detect but by pass.
                    // if visited no worries
                    // do stuff.
                    // however if something can throw then 
                    // it also needs to take into consideration.
                    DatabaseCallPauseFor30SecondsAndThrows();
                }

                MethodThrows();

                var m = x == null; // need to visit this
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);

                if (ReturnsAndThrowsFalse() && PrivateStaticStringProperty1 == null)
                {
                    try
                    {
                        var x = PrivateStaticStringProperty1;
                        // detect blocks here.

                        // Compute in such a way so that it doesn't get visited or by pass or visited then code much reach to the end of try block.
                        if (ReturnsAndThrowsFalse() && p2 == null && p1 == PrivateStringProperty1 || PrivateDateTimeProperty1.Equals(null))
                        {
                            // don't need to detect but by pass.
                            // if visited no worries
                            // do stuff.
                            // however if something can throw then 
                            // it also needs to take into consideration.
                            MethodThrows();
                            DatabaseCallPauseFor30SecondsAndThrowsReturnsTrue();

                            try
                            {
                                // detect blocks here.

                                var x2 = PrivateStaticStringProperty1 + null;

                                MethodThrowsNew();

                                // Compute in such a way so that it doesn't get visited or by pass or if visited then code much reach to the end of try block.
                                if (ReturnsAndThrowsFalse() && p2 == null && p1 == PrivateStringProperty1 || PrivateDateTimeProperty1.Equals(null))
                                {
                                    // don't need to detect but by pass.
                                    // if visited no worries
                                    // do stuff.
                                    // however if something can throw then 
                                    // it also needs to take into consideration.
                                    DatabaseCallPauseFor30SecondsAndThrows();
                                    MethodThrows();
                                }

                                var m3 = x2 == null; // need to visit this
                                var m4 = m3 && e != null; // need to visit this
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception);

                                throw;
                            }
                        }

                        MethodThrows();

                        var m = x == null; // need to visit this
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);

                        throw;
                    }
                }
                //do stuff
                throw;
            }
            catch (ArgumentException argumentException)
            {
                //do stuff
            }
            catch (Exception ex)
            {
                //do stuff
            }
        }

        private void DatabaseCallPauseFor30SecondsAndThrows()
        {
            var x = new Thread(() =>
            {
                Thread.Sleep(30 * 1000);
                throw new Exception("Hello");
            });

            x.Start();
            x.Join();
            throw new Exception("Hello");
        }

        private bool DatabaseCallPauseFor30SecondsAndThrowsReturnsTrue()
        {
            DatabaseCallPauseFor30SecondsAndThrows();
            return true;
        }

        private void MethodThrowsNew()
        {
            throw new Exception("Hello");
        }

        private bool ReturnsAndThrowsFalse()
        {
            throw new Exception("Hello");
            return false;
        }

        private bool ReturnsFalse()
        {
            return false;
        }

        private bool ReturnsFalse(Action action)
        {
            return false;
        }

        private bool ReturnsFalse(IfElseDetectExample ifElseDetectExample)
        {
            return false;
        }

        public void TryCatchWithThrowExample()
        {
            // detect this.
            if (string.IsNullOrEmpty(StringProperty1))
            {
                // do stuff.
                // need to cover this block
            }
            else
            {
                // else part
            }

            // detect this.
            var condition1 = ReturnsFalse();
            var condition2 = PrivateListDateTimeProperty1 == null;
            var condition3 = string.IsNullOrEmpty(StringProperty1);
            var condition4 = ReturnsFalse(() => ReturnsFalse());
            var condition5 = ReturnsFalse(new IfElseDetectExample());
            var finalCondition = condition1 && condition2 || condition3 || condition4 && condition5;

            if (finalCondition && condition3 && DateTime.Parse("1-Mar-2018") == DateTime.Now)
            {
                // do stuff.
                try
                {
                    // do stuff
                    var x = PrivateStaticStringProperty1;
                    var y = x + "";

                    if ("" == PrivateStringProperty1 || PrivateDateTimeProperty1.Equals(null))
                    {
                        // don't detect this.
                        // if visited no worries
                        // do stuff.
                        // however if something can throw then
                        // it also needs to take into consideration.
                    }

                    MethodThrows();
                    MethodThrows(new Exception("Hello Exception"));
                    var m = x == null; // need to visit this
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                    //do stuff
                    MethodThrows(new Exception("Hello Exception"));
                    throw;
                }
                catch (ArgumentException argumentException)
                {
                    //do stuff
                }
                catch (Exception ex)
                {
                    //do stuff
                }
            }
            else
            {
                // else part
            }
        }
    }
}