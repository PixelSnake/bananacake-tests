Feature: Generic types

    Types can take an arbitrary amount of type arguments inside <> brackets.

    Scenario: Generic type can be used in declaration
        Given the following class is defined:
            """
            class Collection<T> {}
            """
        And the main function contains the following code:
            """
            Collection<int> collection;
            """
        When the code is compiled
        Then there are no errors

    Scenario: Generic type constructor can be invoked
        Given the following class is defined:
            """
            class Collection<T> {
                public Collection() {}
            }
            """
        And the main function contains the following code:
            """
            Collection<int> collection = new Collection<int>();
            """
        When the code is compiled
        Then there are no errors

    Scenario: Empty generic type constructor is automatically generated
        Given the following class is defined:
            """
            class Collection<T> {}
            """
        And the main function contains the following code:
            """
            Collection<int> collection = new Collection<int>();
            """
        When the code is compiled
        Then there are no errors

    @Error
    Scenario: Generic type argument can not be omitted in constructor call
        Given the following class is defined:
            """
            class Collection<T> {
                public Collection() {}
            }
            """
        And the main function contains the following code:
            """
            Collection<int> collection = new Collection();
            """
        When the code is compiled
        Then an error is returned
        And the error contains "Illegal use of generic symbol"

    @Error
    Scenario: Generic type argument can not be omitted in call to default constructor
        Given the following class is defined:
            """
            class Collection<T> {}
            """
        And the main function contains the following code:
            """
            Collection<int> collection = new Collection();
            """
        When the code is compiled
        Then an error is returned
        And the error contains "Illegal use of generic symbol"

    Scenario: Constructors of generic classes can have parameters
        Given the following class is defined:
            """
            class Collection<T> {
                public Collection(int x) {
                    TEST("x", x);
                }
            }
            """
        And the main function contains the following code:
            """
            Collection<int> collection = new Collection<int>(1337);
            """
        When the code is compiled
        Then there are no errors
        And "x" evaluates to 1337

    Scenario: Constructors of generic classes can have parameters of the generic type
        Given the following class is defined:
            """
            class Collection<T> {
                public Collection(T x) {}
            }
            """
        And the main function contains the following code:
            """
            Collection<int> collection = new Collection<int>(1337);
            """
        When the code is compiled
        Then there are no errors
        
    @Error
    Scenario: Concrete versions of generic types are treated as different types
        Given the following class is defined:
            """
            class Collection<T> {}
            """
        And the main function contains the following code:
            """
            Collection<int> collection = new Collection<string>();
            """
        When the code is compiled
        Then an error is returned
