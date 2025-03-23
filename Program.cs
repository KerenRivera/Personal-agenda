using System.Diagnostics;

Console.WriteLine("Bienvenido a mi lista de Contactos");
Console.WriteLine("---------------------------------------");


//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada: ");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            {

                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2: //extract this to a method
            {

                ShowContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 3: //search
            {
                SearchContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 4: //modify
            {
                ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 5: //delete
            {
                DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 6:
            runing = false;
            Console.WriteLine("Saliendo...");
            break;
        default:
            Console.WriteLine("¿Tú eres o te haces el idiota?");
            break;
    }
}

static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el nombre de la persona");
    string name = Console.ReadLine();
    Console.WriteLine("Digite el apellido de la persona");
    string lastname = Console.ReadLine();
    Console.WriteLine("Digite la dirección");
    string address = Console.ReadLine();
    Console.WriteLine("Digite el teléfono de la persona");
    string phone = Console.ReadLine();
    Console.WriteLine("Digite el email de la persona");
    string email = Console.ReadLine();
    Console.WriteLine("Digite la edad de la persona en números");
    if (!int.TryParse(Console.ReadLine(), out int age))
    {
        Console.WriteLine("Edad inválida. Contacto no agregado.");
        return;
    }

    Console.WriteLine("Especifique si es mejor amigo: 1. Sí, 2. No");
    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);

    Console.WriteLine("Contacto agregado correctamente.");
}


static void ShowContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
    Console.WriteLine($"");
    foreach (var id in ids)
    {
        var isBestFriend = bestFriends[id];

        string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
    }

}


static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el ID del contacto que desea buscar");

    if (int.TryParse(Console.ReadLine(), out int idBuscado))
    {
        bool finded = false;

        foreach (var id in ids)
        {
            if (id == idBuscado)
            {
                finded = true;
                string isBestFriendStr = bestFriends[id] ? "Si" : "No";

                Console.WriteLine("Contacto:\n");
                Console.WriteLine($"Nombre: {names[id]}");
                Console.WriteLine($"Apellido: {lastnames[id]}");
                Console.WriteLine($"Dirección: {addresses[id]}");
                Console.WriteLine($"Teléfono: {telephones[id]}");
                Console.WriteLine($"Email: {emails[id]}");
                Console.WriteLine($"Edad: {ages[id]}");
                Console.WriteLine($"Es mejor amigo: {isBestFriendStr}");
                Console.WriteLine("----------------------------------------------------\n");
                break;
            }
        }

        if (!finded)
        {
            Console.WriteLine("No se encontró ningún contacto con este ID.");
        }
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }
}

static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Escriba el ID del contacto que desea modificar: ");

    if (int.TryParse(Console.ReadLine(), out int idBuscado))
    {
        bool finded = false;

        foreach (var id in ids)
        {
            if (id == idBuscado)
            {
                finded = true;
                //string isBestFriendStr = bestFriends[id] ? "Si" : "No";

                //Console.WriteLine("Contacto:\n");
                //Console.WriteLine($"Nombre: {names[id]}");
                //Console.WriteLine($"Apellido: {lastnames[id]}");
                //Console.WriteLine($"Dirección: {addresses[id]}");
                //Console.WriteLine($"Teléfono: {telephones[id]}");
                //Console.WriteLine($"Email: {emails[id]}");
                //Console.WriteLine($"Edad: {ages[id]}");
                //Console.WriteLine($"Es mejor amigo: {isBestFriendStr}");
                //Console.WriteLine("----------------------------------------------------\n");
                //break;

                Console.WriteLine("Elija la opcion que desea modificar: ");
                Console.WriteLine($"1. Nombre         2. Apellido          3. Dirección          4. Telefono           5. Email         6. Edad          7. Es Mejor Amigo?\n");
                var option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            Console.WriteLine("Escriba el nuevo nombre: ");
                            string newName = Console.ReadLine();

                            names[idBuscado] = newName;
                            Console.WriteLine("Nombre actualizado correctamente.");

                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Escriba el nuevo apellido: ");
                            string newLastName = Console.ReadLine();

                            lastnames[idBuscado] = newLastName;
                            Console.WriteLine("Apellido actualizado correctamente.");
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Escriba la nueva dirección: ");
                            string newAdress = Console.ReadLine();

                            addresses[idBuscado] = newAdress;
                            Console.WriteLine("Dirección actualizada correctamente.");
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Escriba el nuevo teléfono: ");
                            string newTelephone = Console.ReadLine();

                            telephones[idBuscado] = newTelephone;
                            Console.WriteLine("Teléfono actualizado correctamente.");
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("Escriba el nuevo email: ");
                            string newEmail = Console.ReadLine();

                            emails[idBuscado] = newEmail;
                            Console.WriteLine("Email actualizado correctamente.");
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("Escriba la nueva edad: ");
                            if (int.TryParse(Console.ReadLine(), out int newAge))
                            {
                                ages[idBuscado] = newAge;
                                Console.WriteLine("Edad actualizada correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("Dato inválido. Por favor escriba un número entero.");
                            }
                        }
                        break;
                    case 7:
                        {
                            Console.WriteLine("Es mejor amigo? (Sí/No): ");
                            string answer = Console.ReadLine().ToLower();

                            bestFriends[idBuscado] = (answer == "si");

                            if (answer == "si" || answer == "no")
                            {
                                Console.WriteLine($"El contacto ahora {(bestFriends[idBuscado] ? "es" : "no es")} mejor amigo.");
                            }
                            else
                            {
                                Console.WriteLine("Respuesta inválida. Debe escribir 'Sí' o 'No'.");
                            }
                        }
                        break;
                    default:

                        Console.WriteLine("Por favor, digite una opción válida.");
                        break;
                }
                Console.ReadKey();
            }
        }

        if (!finded)
        {
            Console.WriteLine("No se encontró ningún contacto con este ID.");
        }
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }
}

static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Escriba el ID del contacto que desea eliminar: ");

    if (int.TryParse(Console.ReadLine(), out int idBuscado))
    {
        bool finded = false;

        foreach (var id in ids)
        {
            if (id == idBuscado)
            {
                finded = true;

                ids.Remove(idBuscado);
                names.Remove(idBuscado);
                lastnames.Remove(idBuscado);
                addresses.Remove(idBuscado);
                telephones.Remove(idBuscado);
                emails.Remove(idBuscado);
                ages.Remove(idBuscado);
                bestFriends.Remove(idBuscado);

                Console.WriteLine("Contacto eliminado satisfactoriamente.");
            }

        }
        if (!finded)
        {
            Console.WriteLine("No se encontró ningún contacto con este ID.");
        }
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }
}

