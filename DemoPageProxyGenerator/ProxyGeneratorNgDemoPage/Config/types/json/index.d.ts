///Damit wir für Kendo Ui die passenden JSON Dateien laden für die Internationalisierung laden können
///müssen wir dem TypeScript Compiller erst noch sagen das er auch die JSON Dateien laden soll.
///Dafür muss die tsconfig.json angepasst werden in den Bereichen
/// "typeRoots": ["./Config/types"],
/// "types": ["node", "json"]
/// Jetzt erkennt auch der Compiller die JSON Dateien und kann diese entsprechend laden.
///http://stackoverflow.com/questions/39826848/typescript-2-0-types-field-in-tsconfig-json

declare module "*.json" {
    const value: any;
    export default value;
}