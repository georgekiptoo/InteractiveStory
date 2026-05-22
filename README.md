# Interactive Story Engine 

O aplicatie WinForms pentru crearea si rularea povestilor interactive bazate pe blocuri narative conectate ca un graf orientat. Proiectul include un **editor vizual** complet pentru autori si un **cititor interactiv** pentru jucatori, cu suport pentru conditii complexe (AND/OR/COMPARISON), efecte asupra starii, imagini de fundal si salvare ca arhiva ZIP.

## Functionalitati

- **Editor vizual** cu TreeView pentru structura completa a povestii
- **Blocuri narative** cu id unic, text, imagine de fundal optionala si marcaj de bloc final
- **Decizii** cu text, bloc tinta, conditie optionala, efecte si iconita
- **Conditii** reprezentate ca AST (Abstract Syntax Tree): COMPARISON, AND, OR — imbricate recursiv
- **Editor de conditii pe arbore** — adaugare noduri AND/OR/COMPARISON, editare proprietate/operator/valoare
- **Proprietati de stare numerice** (ex: player.life, inventory.money) cu min/max/initial, HUD, redirectionare automata la min/max
- **Efecte** ADD si SET asupra proprietatilor, cu clamping in [min, max]
- **Filtrare automata** a deciziilor — se afiseaza doar deciziile cu conditii indeplinite
- **Redirectionare automata** la atingerea min/max (ex: player.life = 0 → ending.death)
- **HUD** cu progress bar-uri pentru proprietatile vizibile, ordonate dupa HudOrder
- **Imagini de fundal** per bloc, incluse in arhiva ZIP
- **Salvare/incarcare stare joc** in format JSON
- **Restart** poveste la starea initiala
- **Validare completa** a poveștii (id-uri unice, blocuri existente, proprietati valide, conditii, efecte)
- **Salvare poveste** ca arhiva ZIP cu story.json + director images/

## Tehnologii folosite

**C#, .NET Framework, Windows Forms, Newtonsoft.Json, System.IO.Compression**

## Structura proiectului

```text
InteractiveStory/
├── Story.Model
│   └── StoryDefinition, StoryBlock, DecisionDefinition,
│       StatePropertyDefinition, EffectDefinition, ConditionNode
├── Story.Engine
│   └── GameEngine, GameState, ConditionEvaluator, StoryValidator
├── Story.Persistence
│   └── StoryRepository, ImageRepository,
│       StoryJsonSerializer, ConditionJsonConverter
├── Story.Player.WinForms
│   └── MainForm (aplicatia de citire)
└── Story.Editor.WinForms
    └── EditorMainForm, DecisionEditDialog, ConditionEditorDialog
```

## Cum se ruleaza

**Necesita:** Visual Studio 2019+, .NET Framework 4.8

1. Cloneaza repository-ul sau descarca ZIP-ul
2. Deschide `InteractiveStory.slnx` in Visual Studio
3. Instaleaza NuGet `Newtonsoft.Json` in `Story.Persistence` si `Story.Player.WinForms`
4. Pentru **editor**: click dreapta pe `Story.Editor.WinForms` → Set as Startup Project → F5
5. Pentru **cititor**: click dreapta pe `Story.Player.WinForms` → Set as Startup Project → F5

## Poveste

Fisierul `poveste.zip` contine povestea **"Evadarea din Turnul Intunecat"**.

Povestea demonstreaza toate functionalitatile:
- 4 proprietati de stare (Viata, Energie, Bani, Cheie)
- 8 blocuri narative cu imagini de fundal
- Decizii cu conditii (ex: „Mergi la fereastra" doar daca story.hasKey == 1)
- Decizii cu conditii financiare (ex: „Mitui gardianul" doar daca inventory.money >= 10)
- Efecte multiple (scadere viata, bani, energie; setare cheie)
- Redirectionare automata la moarte (player.life = 0 → ending.death)
- 2 finaluri diferite (evadare / moarte)

Pentru a rula demo-ul:
1. Porneste aplicatia de citire (Story.Player.WinForms)
2. Fisier → Deschide poveste
3. Selecteaza `poveste.zip`

## Controale cititor

| Meniu | Actiune |
|---|---|
| Fisier → Deschide poveste | Incarca o poveste din arhiva ZIP |
| Fisier → Restart | Reia povestea de la inceput |
| Fisier → Salveaza starea | Salveaza starea curenta in JSON |
| Fisier → Incarca starea | Incarca o stare salvata anterior |
| Fisier → Iesire | Inchide aplicatia |
| Click pe buton decizie | Aplica decizia si avanseaza in poveste |

## Controale editor

| Meniu / Buton | Actiune |
|---|---|
| Fisier → Poveste noua | Creeaza o poveste goala |
| Fisier → Deschide | Incarca o poveste existenta din ZIP |
| Fisier → Salveaza / Salveaza ca | Salveaza povestea ca arhiva ZIP |
| Editare → Adauga bloc | Adauga un bloc narativ nou |
| Editare → Adauga proprietate | Adauga o proprietate de stare noua |
| Editare → Sterge selectia | Sterge blocul sau proprietatea selectata |
| Validare → Valideaza povestea | Verifica integritatea poveștii |
| Buton Adauga (decizii) | Adauga o decizie la blocul curent |
| Buton Editeaza (decizii) | Deschide dialogul de editare decizie |
| Buton Sterge (decizii) | Sterge decizia selectata |

## Capturi de ecran
<img width="1366" height="768" alt="Screenshot 2026-05-22 000209" src="https://github.com/user-attachments/assets/a64fb480-a894-4b44-ae5f-ce8823e22deb" />
<img width="1366" height="768" alt="Screenshot 2026-05-22 000223" src="https://github.com/user-attachments/assets/26ad6021-a0cb-4447-bb3b-b78b05459f6c" />
<img width="1366" height="768" alt="Screenshot 2026-05-22 000232" src="https://github.com/user-attachments/assets/8d1fc28a-f932-47e1-9caa-f49fdea3c3a3" />
<img width="1366" height="768" alt="Screenshot 2026-05-22 000240" src="https://github.com/user-attachments/assets/2572871d-22bf-4829-bfcb-c53a0dfd22f8" />
<img width="1366" height="768" alt="Screenshot 2026-05-22 000248" src="https://github.com/user-attachments/assets/4ab671df-ea7c-40d5-9dec-1de648d6cc10" />
<img width="1366" height="768" alt="Screenshot 2026-05-22 000256" src="https://github.com/user-attachments/assets/c142b5bd-2f40-4589-afe4-51423913b171" />

## Ce am invatat

**Serializare polimorfica JSON:** Conditiile sunt reprezentate ca AST (Abstract Syntax Tree) cu noduri de tip COMPARISON, AND si OR imbricate recursiv. Am implementat un `JsonConverter` custom in Newtonsoft.Json care citeste campul `"type"` din JSON si instantiaza clasa concreta corecta (`ComparisonCondition`, `AndCondition`, `OrCondition`).

**Separare pe straturi (Layered Architecture):** Proiectul e structurat in 5 straturi independente — Model, Engine, Persistence, Player UI, Editor UI. Fiecare strat depinde doar de straturile de sub el, niciodata invers. Asta permite modificarea UI-ului fara sa atingi logica de joc.

**Graf orientat pentru povesti:** Blocurile narative sunt stocate intr-un `Dictionary<string, StoryBlock>` pentru acces O(1) dupa id. Decizia unui utilizator reprezinta o muchie in graful orientat al poveștii.

**Evaluare recursiva AST:** `ConditionEvaluator` parcurge arborele de conditii recursiv — AND se opreste la primul `false`, OR la primul `true` (short-circuit evaluation).

**WinForms dinamic:** Formularele de editare din centrul editorului sunt generate dinamic prin cod (nu prin designer) in functie de tipul nodului selectat in TreeView — bloc, proprietate sau radacina.

**Arhive ZIP cu resurse:** Povestea se salveaza ca arhiva ZIP cu `story.json` + director `images/`. Imaginile sunt citite in memorie din stream-uri si pastrate independent de arhiva pentru a evita invalidarea la inchiderea ZIP-ului.

## Autor

Realizat ca tema de semestru pentru cursul POO/PCLP3, 2026.

Link GitHub: https://github.com/georgekiptoo/InteractiveStory
