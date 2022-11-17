#region var
string mode;
string player_got_point;
int player1_points = 0;
int player2_points = 0;
int player1_games = 0;
int player2_games = 0;
int quantity_games = 0;
int player_service = 0;
int service_rounds = 0;

const int POINTS_NEEDED = 11;
const int SHORT_GAMES = 1;
const int REGULAR_GAMES = 4;
const int DOUBLE_GAMES = 3;
const string PLAYER1_WON_GAME = "Player 1 won the game.\n";
const string PLAYER2_WON_GAME = "Player 2 won the game.\n";
const string PLAYER1_WON_MATCH = "Congratulations, Player 1 won the match.\n";
const string PLAYER2_WON_MATCH = "Congratulations, Player 2 won the match.\n";
const string DECIDE_MODE = "Please enter the mode you want to play: ";
const string CUSTOM_GAMES = "Please enter the games that have to be won: ";
const string DECIDE_PLAYER = "Please enter the player that won the round or q for quit: ";
#endregion

do
{
    Console.Write(DECIDE_MODE);
    mode = Console.ReadLine()!.ToLower();
} while (mode != "short" && mode != "regular" && mode != "double" && mode != "custom");

switch (mode)
{
    case "short":
        quantity_games = SHORT_GAMES;
        break;
    case "regular":
        quantity_games = REGULAR_GAMES;
        break;
    case "double":
        quantity_games = DOUBLE_GAMES;
        break;
    case "custom":
        do
        {
            Console.Write(CUSTOM_GAMES);
            quantity_games = int.Parse(Console.ReadLine()!);
        } while (quantity_games <= 0 || quantity_games > 9 || quantity_games % 2 == 0);
        break;
}

while (player1_games != quantity_games && player2_games != quantity_games)
{
    if (player1_points == 0 && player2_points == 0)
    {
        player_service = Random.Shared.Next(1, 3);
    }
    Console.WriteLine($"Player {player_service} serves!");
    do
    {
        Console.Write(DECIDE_PLAYER);
        player_got_point = Console.ReadLine()!;
    } while (player_got_point != "1" && player_got_point != "2" && player_got_point != "q");

    switch (player_got_point)
    {
        case "1": player1_points++; break;
        case "2": player2_points++; break;
        case "q": return;
    }
    service_rounds++;
    if (service_rounds == 2 && player_service == 1)
    {
        player_service = 2;
        service_rounds = 0;
    }
    else if (service_rounds == 2 && player_service == 2)
    {
        player_service = 1;
        service_rounds = 0;
    }
    if (player1_points == POINTS_NEEDED)
    {
        Console.WriteLine(PLAYER1_WON_GAME);
        player1_games++;
        player1_points = 0;
        player2_points = 0;
    }
    else if (player2_points == POINTS_NEEDED)
    {
        Console.WriteLine(PLAYER2_WON_GAME);
        player2_games++;
        player1_points = 0;
        player2_points = 0;
    }
    Console.WriteLine($"Games: {player1_games}:{player2_games}, Rounds: {player1_points}:{player2_points}");
}
if (player1_games == quantity_games) { Console.Write(PLAYER1_WON_MATCH); }
else { Console.Write(PLAYER2_WON_MATCH); }