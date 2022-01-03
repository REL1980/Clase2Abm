// Acá vamos a construir la Api Rest
//1 hora de clase2

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var teams = new List<Team>();

var index = 1;
var team = new Team("Barcelona");
team.Id = index;

teams.Add(team);


// Get All : Devolver o Mostrar todos los Teams(equipos)
// Si tengo que devolver todos devuelvo una Lista de equipos.
app.MapGet("/api/teams", () => teams);  // MapGet para mostrar


// Get : Devolver o Mostrar un solo equipo
// Si tengo que devolver uno solo devería pasarle un id 
// y devolver ése solo.
 app.MapGet("/api/teams/{id}", (int id) => {  // MapGet para mostrar
    
     var team = teams.FirstOrDefault(x => x.Id == id); // expreción landa (hacer una programación en 1 línea)
     return team; 
 });

// Create : Crear
 app.MapPost("/api/teams", (Team teamInput) => {    // MapPost para crear
     
     var exist = teams.FirstOrDefault(x => x.Name.ToLower() == teamInput.Name.ToLower());
     //si hay algo en exist va a devolver algo, si no va a devolver Null

     if(exist != null)
     {
         return false;
     }

     index = index +1;
     teamInput.Id = index;
     teams.Add(teamInput);
     return true; 
 });

// Edit : Editar o Cambiar
app.MapPut("/api/teams", (Team teamInput) => {    // MapPut para editar o cambiar
//dotnet tiene todos éstos mapeos pre establecidos
     
     var team = teams.FirstOrDefault(x => x.Id == teamInput.Id);
     //si hay algo en exist va a devolver algo, si no va a devolver Null

     if(team == null)
     {
         return false;
     }

     //reemplazar éste elemento
     teams.Remove(team);
     teams.Add(teamInput);

     return true; 
 });

// Delete : Borrar
app.MapDelete("/api/teams/{id}", (int id) => {    // MapDelete borrar

     
     var team = teams.FirstOrDefault(x => x.Id == id);
     

     if(team == null)
     {
         return false;
     }

     //borrar éste elemento
     teams.Remove(team);
     return true; 
 });


app.Run();
