using FashionDressingGame.Database;
using FashionDressingGame.Service;

namespace FashionDressingGame.UI;

public class Update : New
{
    public override int Start()
    {
        Navigation navigation = new Navigation();

        List<Func<int>> actions = new List<Func<int>>()
        {
            GetCharacterInfo,
            GetAppearanceInfo,
            GetClothingInfo,
        };

        int i = 0;
        navigation.Navigate(actions[i]);

        while (true)
        {
            int result = navigation.ShowCurrentWindow();

            if (result == 0)
            {
                i--;
                if (i >= 0)
                {
                    navigation.GoBack();
                }
                else
                {
                    return 0;
                }
            }
            else if (result == 1)
            {
                i++;
                if (i < actions.Count)
                {
                    navigation.Navigate(actions[i]);
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                break;
            }
        }
        return 0;
    }
    public override void SetCharacter()
    {
        NewAppearance = new Appearance(_appearanceInfo.Skintone, _appearanceInfo.Eyecolor, _appearanceInfo.Haircolor,
            _appearanceInfo.Hairstyle, _appearanceInfo.Faceshape);
        NewTop = new Top(_topInfo.TopType!, _topInfo.TopMaterial!);
        NewBottom = new Bottom(_bottomInfo.BottomType!, _bottomInfo.BottomMaterial!);
        NewJewelry = new Jewelry(_jewelryInfo.Watches, _jewelryInfo.Earrings, _jewelryInfo.Chains, _jewelryInfo.Anklets, _jewelryInfo.Cufflinks);
        NewOuterWear = new OuterWear(_outerwearInfo.Outerwear!, _outerwearInfo.OuterwearType!);
        NewClothing = new Clothing(NewTop, NewBottom, _clothingInfo.ShoeType!, _clothingInfo.Accessory!, _clothingInfo.Gloves!,
            NewJewelry, _clothingInfo.OutfitThemes!, _clothingInfo.FormalWear!, NewOuterWear, _clothingInfo.Hat!);
        
        NewCharacter = new Character(_characterInfo.Name, _characterInfo.Gender, _characterInfo.Height, _characterInfo.Age, NewAppearance, NewClothing);
    }

    public void InjectState(ECharacter character)
    {
        //Character Info
        _nameText.Text = character.Name;
        _characterInfo.Name = character.Name;
        _characterInfo.Gender = character.Gender;
        _characterInfo.Height = character.Height;
        _characterInfo.Age = character.Age;
        _characterMenu.SetFormValue("Gender", character.Gender);
        _characterMenu.SetFormValue("Height", character.Height);
        _characterMenu.SetFormValue("Age", character.Age);
        
        //Appearance Info
        _appearanceInfo.Skintone = character.Appearance.SkinTone;
        _appearanceInfo.Faceshape = character.Appearance.FaceShape;
        _appearanceInfo.Eyecolor = character.Appearance.EyeColor;
        _appearanceInfo.Haircolor = character.Appearance.HairColor;
        _appearanceInfo.Hairstyle = character.Appearance.HairStyle;
        _appearanceInfo.Freckles = character.Appearance.Freckles;
        _appearanceInfo.Dimple = character.Appearance.Dimples;
        _appearanceInfo.Acne = character.Appearance.Acne;
        _appearanceMenu.SetFormValue("Skin Tone", character.Appearance.SkinTone);
        _appearanceMenu.SetFormValue("Eye Color", character.Appearance.EyeColor);
        _appearanceMenu.SetFormValue("Hair Style", character.Appearance.HairStyle);
        _appearanceMenu.SetFormValue("Hair Color", character.Appearance.HairColor);
        _appearanceMenu.SetFormValue("Face Shape", character.Appearance.FaceShape);
        _appearanceMenu.SetFormValue("Optional", GetBoolAppearance(character));
        
        //Top Info
        _topInfo.TopType = character.Clothing.Top.Type;
        _topInfo.TopMaterial = character.Clothing.Top.Material;
        _topMenu.SetFormValue("Type", character.Clothing.Top.Type);
        _topMenu.SetFormValue("Material", character.Clothing.Top.Material);
        
        //Bottom Info
        _bottomInfo.BottomType = character.Clothing.Bottom.Type;
        _bottomInfo.BottomMaterial = character.Clothing.Bottom.Material;
        _topMenu.SetFormValue("Type", character.Clothing.Bottom.Type);
        _topMenu.SetFormValue("Material", character.Clothing.Bottom.Material);
        
        //OuterWear Info
        _outerwearInfo.Outerwear = character.Clothing.OuterWear.OuterWearName;
        _outerwearInfo.OuterwearType = character.Clothing.OuterWear.OuterWearType;
        _outerWearMenu.SetFormValue("Outer Wear", character.Clothing.OuterWear.OuterWearName);
        _outerWearMenu.SetFormValue("Outer Wear Type", character.Clothing.OuterWear.OuterWearType);
        
        //Jewelry Info
        _jewelryInfo.Cufflinks = character.Clothing.Jewelry.Cufflinks;
        _jewelryInfo.Watches = character.Clothing.Jewelry.Watches;
        _jewelryInfo.Earrings = character.Clothing.Jewelry.Earrings;
        _jewelryInfo.Chains = character.Clothing.Jewelry.Chains;
        _jewelryInfo.Anklets = character.Clothing.Jewelry.Anklets;
        _jewelMenu.SetFormValue("Watches", character.Clothing.Jewelry.Watches ?? string.Empty);
        _jewelMenu.SetFormValue("Earrings", character.Clothing.Jewelry.Earrings ?? string.Empty);
        _jewelMenu.SetFormValue("Chains", character.Clothing.Jewelry.Chains ?? string.Empty);
        _jewelMenu.SetFormValue("Anklets", character.Clothing.Jewelry.Anklets ?? string.Empty);
        _jewelMenu.SetFormValue("Cufflinks", character.Clothing.Jewelry.Cufflinks ?? string.Empty);
        
        //Clothing Info
        _clothingInfo.Accessory = character.Clothing.Accessory;
        _clothingInfo.Gloves = character.Clothing.Gloves;
        _clothingInfo.Hat = character.Clothing.Hat;
        _clothingInfo.FormalWear = character.Clothing.FormalWear;
        _clothingInfo.OutfitThemes = character.Clothing.OutfitTheme;
        _clothingInfo.ShoeType = character.Clothing.Shoe;
        _clothingMainMenu.SetFormValue("Top", $"{_topInfo.TopType} : {_topInfo.TopMaterial}");
        _clothingMainMenu.SetFormValue("Bottom", $"{_bottomInfo.BottomType} : {_bottomInfo.BottomMaterial}");
        _clothingMainMenu.SetFormValue("Jewelry", _getJewelryEmojis(_jewelryInfo));
        _clothingMainMenu.SetFormValue("Outer Wear", $"{_outerwearInfo.Outerwear} : {_outerwearInfo.OuterwearType}");
        _clothingMainMenu.SetFormValue("Shoe", character.Clothing.Shoe);
        _clothingMainMenu.SetFormValue("Accessory", character.Clothing.Accessory);
        _clothingMainMenu.SetFormValue("Gloves", character.Clothing.Gloves);
        _clothingMainMenu.SetFormValue("Hat", character.Clothing.Hat);
        _clothingMainMenu.SetFormValue("Outfit Themes", character.Clothing.OutfitTheme);
        _clothingMainMenu.SetFormValue("Formal Wear", character.Clothing.FormalWear);
        
        //Bool Checkbox
        if (_checkboxWidget != null)
        {
            foreach (var option in _checkboxWidget.CheckedStates.Keys.ToList())
            {
                bool state = option switch
                {
                    "Freckles" => character.Appearance.Freckles,
                    "Dimples" => character.Appearance.Dimples,
                    "Acne" => character.Appearance.Acne,
                    _ => false
                };

                _checkboxWidget.CheckedStates[option] = state;
            }
        }
    }

    private string GetBoolAppearance(ECharacter character)
    {
        List<string> selectedFeatures = new List<string>();
        if (character.Appearance.Freckles)
        {
            selectedFeatures.Add("[Freckles]");
        }
        if (character.Appearance.Dimples)
        {
            selectedFeatures.Add("[Dimples]");
        }
        if (character.Appearance.Acne)
        {
            selectedFeatures.Add("[Acne]");
        }
        if (selectedFeatures.Count > 2)
        {
            return string.Join(", ", selectedFeatures.Take(2)) + " ...";
        }
        return string.Join(", ", selectedFeatures);
    }

}