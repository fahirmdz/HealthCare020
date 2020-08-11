===================== Validation requirements ====================
1. Kreirati ViewModel koji nasledjuje BaseValidationViewModel
2. Kreirati Page koji nasledjuje BaseValidationContentPage
3. U konstruktoru Page-a
     1) Postaviti => BaseValidationVM = TrenutniViewModel;
     2) Pozvati => SetFormBodyElement();
                   SetErrorsClearOnTextChanged();
4. Za StackLayout koji je body glavne forme, postaviti x:Name="FormBody"
4. Svaki entry u na stranici treba imati ClassId koji odgovara nazivu property-ja u ViewModel-u, moraju se poklapati
5. Ukoliko zelimo validation message, ispod Entry-ja ide Label sa x:Name="PropertyNameValidation" (PropertyName trebamo zameniti sa nazivom propertyja)
6. Kako bi forsirali validaciju prije nego se izvrsi zeljena funkciolanost, u sklopu Page-a se poziva => ValidateModel() , koji vraca TRUE za uspesnu validaciju