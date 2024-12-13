using FashionDressingGame.Database;
using Microsoft.EntityFrameworkCore;

namespace FashionDressingGame.Service;

public static class DatabaseUtils
{
    private static FashionGameDbContext _dbContext = new FashionGameDbContext();
    private static CharacterService _characterService = new CharacterService(_dbContext);

    public static void AddCharacter(ECharacter? character)
    {
        if (character == null)
        {
            throw new ArgumentNullException(nameof(character), "Character cannot be null.");
        }

        _characterService.AddCharacter(character);
    }

    public static void UpdateCharacter(int characterId, ECharacter updatedCharacter)
    {
        if (updatedCharacter == null)
        {
            throw new ArgumentNullException(nameof(updatedCharacter), "Updated character cannot be null.");
        }

        _characterService.UpdateCharacter(characterId, updatedCharacter);
    }

    public static void DeleteCharacter(int characterId)
    {
        _characterService.DeleteCharacter(characterId);
    }

    public static ECharacter? GetCharacterById(int characterId)
    {
        return _characterService.GetCharacterById(characterId);
    }

    public static Dictionary<int, ECharacter> GetAllCharactersAsDictionary()
    {
        return _characterService.GetAllCharactersAsDictionary(); 
    }
}