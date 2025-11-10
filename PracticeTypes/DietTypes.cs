namespace MyZooProject
{
    // STEP 4: ENUMS
    // An "enum" is a list of named constants.
    // It makes code safer and more readable.
    // Instead of using a string "Carnivore", which could be
    // misspelled, we use DietType.Carnivore.
    // The compiler will give an error if we use a value that doesn't exist.
    public enum DietType
    {
        Carnivore, // Eats meat
        Herbivore, // Eats plants
        Omnivore,  // Eats both
        Unknown    // Default
    }
}