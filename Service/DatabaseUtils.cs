using FashionDressingGame.Database;
using Microsoft.EntityFrameworkCore;

namespace FashionDressingGame.Service;

public static class DatabaseUtils
{
    private static FashionGameDbContext _dbContext = new FashionGameDbContext();
    private static CharacterService _characterService = new CharacterService(_dbContext);

    public static string AddCharacter(ECharacter? character)
    {
        try
        {
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character), "Character cannot be null.");
            }

            _characterService.AddCharacter(character);
            return "Character added successfully.";
        }
        catch (Exception ex)
        {
            return $"Failed to add character: {ex.Message}";
        }
    }

    public static string UpdateCharacter(int characterId, ECharacter updatedCharacter)
    {
        try
        {
            if (updatedCharacter == null)
            {
                throw new ArgumentNullException(nameof(updatedCharacter), "Updated character cannot be null.");
            }

            _characterService.UpdateCharacter(characterId, updatedCharacter);
            return "Character updated successfully.";
        }
        catch (KeyNotFoundException knfEx)
        {
            return $"Character update failed: {knfEx.Message}";
        }
        catch (Exception ex)
        {
            return $"Failed to update character: {ex.Message}";
        }
    }

    public static string DeleteCharacter(int characterId)
    {
        try
        {
            _characterService.DeleteCharacter(characterId);
            return "Character deleted successfully.";
        }
        catch (KeyNotFoundException knfEx)
        {
            return $"Character deletion failed: {knfEx.Message}";
        }
        catch (Exception ex)
        {
            return $"Failed to delete character: {ex.Message}";
        }
    }

    public static (ECharacter? character, string message) GetCharacterById(int characterId)
    {
        try
        {
            var character = _characterService.GetCharacterById(characterId);
            if (character == null)
            {
                return (null, $"Character with ID {characterId} not found.");
            }
            return (character, "Character retrieved successfully.");
        }
        catch (Exception ex)
        {
            return (null, $"Failed to retrieve character: {ex.Message}");
        }
    }

    public static (Dictionary<int, ECharacter> characters, string message) GetAllCharactersAsDictionary()
    {
        try
        {
            var characters = _characterService.GetAllCharactersAsDictionary();
            if (characters.Count == 0)
            {
                return (characters, "No characters found in the database.");
            }
            return (characters, "Characters retrieved successfully.");
        }
        catch (Exception ex)
        {
            return (null, $"Failed to retrieve characters: {ex.Message}");
        }
    }
}
