using FashionDressingGame.Database;
using Microsoft.EntityFrameworkCore;

namespace FashionDressingGame.Service;

public class CharacterService
{
    private readonly FashionGameDbContext _dbContext;

    public CharacterService(FashionGameDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Add a new character to the database
    public void AddCharacter(ECharacter? character)
    {
        if (character == null)
        {
            throw new ArgumentNullException(nameof(character), "Character cannot be null.");
        }

        // Check if the Characters table is empty
        var rowCount = _dbContext.Characters.Count();

        if (rowCount == 0)
        {
            // Reset the AUTO_INCREMENT to 1 for all relevant tables
            ResetAutoIncrement("Characters");
            ResetAutoIncrement("Appearances");
            ResetAutoIncrement("Tops");
            ResetAutoIncrement("Bottoms");
            ResetAutoIncrement("OuterWears");
            ResetAutoIncrement("Jewelries");
            ResetAutoIncrement("Clothings");
        }

        // Add the new character
        _dbContext.Characters.Add(character);
        _dbContext.SaveChanges();  // Synchronous SaveChanges
    }

    private void ResetAutoIncrement(string tableName)
    {
        _dbContext.Database.ExecuteSqlRaw($"ALTER TABLE {tableName} AUTO_INCREMENT = 1");
    }

    
    // Update an existing character by ID
    public void UpdateCharacter(int characterId, ECharacter updatedCharacter)
{
    if (updatedCharacter == null)
    {
        throw new ArgumentNullException(nameof(updatedCharacter), "Updated character cannot be null.");
    }

    var character = _dbContext.Characters
        .Include(c => c.Appearance)
        .Include(c => c.Clothing)
            .ThenInclude(cl => cl.Top)
        .Include(c => c.Clothing)
            .ThenInclude(cl => cl.Bottom)
        .Include(c => c.Clothing)
            .ThenInclude(cl => cl.OuterWear)
        .Include(c => c.Clothing)
            .ThenInclude(cl => cl.Jewelry)
        .FirstOrDefault(c => c.Id == characterId); 

    if (character != null)
    {
        // Update character fields
        character.Name = updatedCharacter.Name;
        character.Gender = updatedCharacter.Gender;
        character.Height = updatedCharacter.Height;
        character.CharacterGrade = updatedCharacter.CharacterGrade;

        // Update existing Appearance entity
        if (character.Appearance != null)
        {
            character.Appearance.FaceShape = updatedCharacter.Appearance.FaceShape;
            character.Appearance.HairColor = updatedCharacter.Appearance.HairColor;
            character.Appearance.HairStyle = updatedCharacter.Appearance.HairStyle;
            character.Appearance.Freckles = updatedCharacter.Appearance.Freckles;
            character.Appearance.Dimples = updatedCharacter.Appearance.Dimples;
            character.Appearance.Acne = updatedCharacter.Appearance.Acne;
            character.Appearance.SkinTone = updatedCharacter.Appearance.SkinTone;
            character.Appearance.EyeColor = updatedCharacter.Appearance.EyeColor;
        }

        if (character.Clothing != null)
        {
            // Update Top
            if (character.Clothing.Top != null)
            {
                character.Clothing.Top.Type = updatedCharacter.Clothing.Top.Type;
                character.Clothing.Top.Material = updatedCharacter.Clothing.Top.Material;
            }

            // Update Bottom
            if (character.Clothing.Bottom != null)
            {
                character.Clothing.Bottom.Type = updatedCharacter.Clothing.Bottom.Type;
                character.Clothing.Bottom.Material = updatedCharacter.Clothing.Bottom.Material;
            }

            // Update OuterWear
            if (character.Clothing.OuterWear != null)
            {
                character.Clothing.OuterWear.OuterWearType = updatedCharacter.Clothing.OuterWear.OuterWearType;
                character.Clothing.OuterWear.OuterWearName = updatedCharacter.Clothing.OuterWear.OuterWearName;
            }

            // Update Jewelry
            if (character.Clothing.Jewelry != null)
            {
                character.Clothing.Jewelry.Cufflinks = updatedCharacter.Clothing.Jewelry.Cufflinks;
                character.Clothing.Jewelry.Anklets = updatedCharacter.Clothing.Jewelry.Anklets;
                character.Clothing.Jewelry.Watches = updatedCharacter.Clothing.Jewelry.Watches;
                character.Clothing.Jewelry.Earrings = updatedCharacter.Clothing.Jewelry.Earrings;
            }

            // Update other clothing properties
            character.Clothing.Shoe = updatedCharacter.Clothing.Shoe;
            character.Clothing.Accessory = updatedCharacter.Clothing.Accessory;
            character.Clothing.Gloves = updatedCharacter.Clothing.Gloves;
            character.Clothing.OutfitTheme = updatedCharacter.Clothing.OutfitTheme;
            character.Clothing.FormalWear = updatedCharacter.Clothing.FormalWear;
            character.Clothing.Hat = updatedCharacter.Clothing.Hat;
        }

        // Save changes to the database
        _dbContext.SaveChanges(); // Synchronous SaveChanges
    }
    else
    {
        throw new KeyNotFoundException($"Character with ID {characterId} not found.");
    }
}

    // Delete a character by ID
    public void DeleteCharacter(int characterId)
    {
        // Fetch the character with related entities
        var character = _dbContext.Characters
            .Include(c => c.Appearance)
            .Include(c => c.Clothing)
            .ThenInclude(cl => cl.Top)
            .Include(c => c.Clothing)
            .ThenInclude(cl => cl.Bottom)
            .Include(c => c.Clothing)
            .ThenInclude(cl => cl.Jewelry)
            .Include(c => c.Clothing)
            .ThenInclude(cl => cl.OuterWear)
            .FirstOrDefault(c => c.Id == characterId);

        if (character == null)
        {
            throw new KeyNotFoundException($"Character with ID {characterId} not found.");
        }

        // Remove associated Appearance
        if (character.Appearance != null)
        {
            _dbContext.Appearances.Remove(character.Appearance);
        }

        // Remove associated Clothing and its related entities
        if (character.Clothing != null)
        {
            // Remove related entities in Clothing
            if (character.Clothing.Top != null)
            {
                _dbContext.Tops.Remove(character.Clothing.Top);
            }

            if (character.Clothing.Bottom != null)
            {
                _dbContext.Bottoms.Remove(character.Clothing.Bottom);
            }

            if (character.Clothing.Jewelry != null)
            {
                _dbContext.Jewelries.Remove(character.Clothing.Jewelry);
            }

            if (character.Clothing.OuterWear != null)
            {
                _dbContext.OuterWears.Remove(character.Clothing.OuterWear);
            }

            // Remove the Clothing itself
            _dbContext.Clothings.Remove(character.Clothing);
        }

        // Remove the Character itself
        _dbContext.Characters.Remove(character);

        // Save changes
        _dbContext.SaveChanges();
    }

    // Get a character by its ID with related entities (Appearance and Clothing)
    public ECharacter? GetCharacterById(int characterId)
    {
        return _dbContext.Characters
            .Include(c => c.Appearance)
            .Include(c => c.Clothing)
            .FirstOrDefault(c => c.Id == characterId);  // Synchronous query
    }

    // Get all characters as a dictionary (ID -> Character)
    public Dictionary<int, ECharacter> GetAllCharactersAsDictionary()
    {
        var characters = _dbContext.Characters
            .Include(c => c.Appearance)
            .Include(c => c.Clothing)
                .ThenInclude(cl => cl.Bottom)
            .Include(c => c.Clothing)
                .ThenInclude(cl => cl.Jewelry)
            .Include(c => c.Clothing)
                .ThenInclude(cl => cl.OuterWear)
            .Include(c => c.Clothing)
                .ThenInclude(cl => cl.Top)
            .ToList();  // Synchronous ToList

        return characters.ToDictionary(c => c.Id);
    }
}
