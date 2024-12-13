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

        _dbContext.Characters.Add(character);
        _dbContext.SaveChanges();  // Synchronous SaveChanges
    }

    // Update an existing character by ID
    public void UpdateCharacter(int characterId, ECharacter updatedCharacter)
    {
        if (updatedCharacter == null)
        {
            throw new ArgumentNullException(nameof(updatedCharacter), "Updated character cannot be null.");
        }

        var character = _dbContext.Characters.Find(characterId); // Synchronous Find
        if (character != null)
        {
            // Update fields of the character
            character.Name = updatedCharacter.Name;
            character.AppearanceID = updatedCharacter.AppearanceID;
            character.ClothingID = updatedCharacter.ClothingID;
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
            .ToList();  // Synchronous ToList

        return characters.ToDictionary(c => c.Id);
    }
}
