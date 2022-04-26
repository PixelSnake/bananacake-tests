Feature: Generic types

    Types can take an arbitrary amount of type arguments inside <> brackets.

    Background:
        Given the following class is defined:
            """
            class Collection<T> {}
            """

    Scenario: Generic type can be used in declaration
        Given the main function contains the following code:
            """
            Collection<int> collection;
            """
        When the code is compiled
        Then there are no errors

    Scenario: Generic type constructor can be invoked
        Given the main function contains the following code:
            """
            Collection<int> collection = new Collection<int>();
            """
        When the code is compiled
        Then there are no errors

    Scenario: Generic type argument can be omitted in constructor call
        Given the main function contains the following code:
            """
            Collection<int> collection = new Collection();
            """
        When the code is compiled
        Then there are no errors
