namespace SampleCodeBase.MethodPropertiesWithBusinessValue
{
    public class DependencySetupExmaple
    {
        /// <summary>
        /// Needs to cover 100%
        /// </summary>
        private int IntThrows
        {
            get
            {
                Utility.ThrowExceptionDifferent();

                return 1;
            }
        }

        /// <summary>
        /// Needs to cover 100%
        /// </summary>
        private static int IntStaticThrows
        {
            get
            {
                Utility.ThrowExceptionDifferent();

                return 1;
            }
        }

        /// <summary>
        ///     Cover this method we can just call it directly after faking or mocking with MS Fakes. Inner methods
        ///     "BusinessMethod" and properties (IntThrows) needs to be faked.
        ///     Generator should have intelligence of finding that this method doesn't have any other invocation expression.
        /// </summary>
        public void BusinessMethodInitial()
        {
            var inx = IntStaticThrows;
            dynamic somethingComplex = this;
            var required = new Required();

            BusinessMethod(inx, somethingComplex, required);
        }

        /// <summary>
        ///     Cover this method we can just call it directly after faking or mocking with MS Fakes. Inner methods
        ///     "BusinessMethod" and properties (IntThrows) needs to be faked.
        ///     Generator should have intelligence of finding that this method doesn't have any other invocation expression.
        /// </summary>
        public void BusinessMethodInitial2()
        {
            var inx = IntThrows;
            dynamic somethingComplex = this;
            var required = new Required();

            BusinessMethod(inx, somethingComplex, required);
        }

        /// <summary>
        ///     To test this method we need to find invocation expression of "BusinessMethod" in "BusinessMethodInitial2" and
        ///     "BusinessMethodInitial"
        ///     And create two test method accordingly.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="somethingComplex"></param>
        /// <param name="required"></param>
        public void BusinessMethod(int x, dynamic somethingComplex, IRequired required)
        {
            var prep = new RequiredPrep();
            var classWithProperties = new ClassWithProperties(required);
            var classWithMethods = new ClassWithMethods(required);

            BusinessMethodDependency(somethingComplex, x, classWithProperties, classWithMethods, required, prep);
        }

        /// <summary>
        ///     Now try to understand this scenario, to call this method we need to pass these parameters.
        ///     Now there is no way to understand what these parameters are or how these parameters needs to be passed.
        ///     To find that we need to find Invoking Expression of "BusinessMethodDependency" and detects all it's parameter
        ///     initialize recursively.
        ///     To find dependencies we need to find the method "BusinessMethod" programmatically not hard coded fashion.
        ///     To test this method, we need to 2 setup methods
        ///         1.  Setup of Parameters from "BusinessMethod".
        ///         2.  Setup of inner properties (IntThrows, IntStaticThrows, PubliceByteProp, PublicStringProp), fields,
        ///         methods (ArgumentNullException, SomethingDynamicComplex, ThrowException,
        ///         BusinessLogicExampleOfSameplemethod, BusinessLogicExampleOfSamepleMethodString,
        ///         SampleMethod, SampleMethodString, ThrowException("Needs to be covered" + intX + y))
        /// </summary>
        /// <param name="somethingComplex"></param>
        /// <param name="sample"></param>
        /// <param name="classWithProperties"></param>
        /// <param name="classWithMethods"></param>
        /// <param name="required"></param>
        /// <param name="prep"></param>
        public void BusinessMethodDependency(dynamic somethingComplex,
                                             dynamic sample,
                                             ClassWithProperties classWithProperties,
                                             ClassWithMethods classWithMethods,
                                             IRequired required,
                                             IRequiredPrep prep)
        {
            Utility.ArgumentNullException("Testing"); // this method needs to be Faked
            somethingComplex.SomethingDynamicComplex();
            var x = classWithProperties.PubliceByteProp;
            var y = classWithProperties.PublicStringProp;
            Utility.ThrowException(); // this method needs to be Faked

            var classWithBusinessLogic = new ClassWithBusinessLogic(required);

            classWithBusinessLogic.BusinessLogicExampleOfSameplemethod();
            y = classWithBusinessLogic.BusinessLogicExampleOfSamepleMethodString() + x;

            var classWithBusinessLogic2 = new ClassWithBusinessLogic2();

            classWithBusinessLogic2.SampleMethodString();

            var requiredConcrete = new Required();
            requiredConcrete.SampleMethod(prep);
            requiredConcrete.SampleMethodString(prep);

            var intX = (int) sample + 5 + IntThrows + IntStaticThrows;

            Utility.ThrowException("Needs to be covered" + intX + y); // this method needs to be Faked and covered
        }

        public void SomethingDynamicComplex()
        {
            // do some complex stuff.
            Utility.ThrowException("Needs to be coveredWWWW"); // this method needs to be Faked and covered
            var intX = (int) sample + 5 + IntThrows + IntStaticThrows;
        }
    }
}