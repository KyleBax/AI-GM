﻿using AI_GM.Characters;
using AI_GM.Combat;
using AI_GM.Monsters;
using AI_GM.UserInterface;
using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using static AI_GM.Map.EnumDoorSide;

namespace AI_GM.Map
{
    internal class RoomManager
    {
        public static List<Room> town;
        public static List<Room> mainRooms;
        public static List<Room> startingRooms;
        public static List<Room> exitRooms;
        public static List<Room> bossRooms;
        public static Room room = new Room();
        public static bool newRoom = false;
        public static bool playerLocationUpdated = true;
        public static bool endTurnEarly = false;
        public static bool playerDead = false;
        public static bool roomSearched = true;
        public static bool chestFound = false;
        public static bool bossRoom = false;
        public static bool trapsSearched = false;
        public static int floorLevel = 1;
        public static bool InitialiseMaps(Campaign campaign)
        {
            town = GetRoomsFromTextFile(FilePaths.TOWN);
            mainRooms = GetRoomsFromTextFile(FilePaths.MAINROOMS);
            startingRooms = GetRoomsFromTextFile(FilePaths.STARTINGROOMS);
            exitRooms = GetRoomsFromTextFile(FilePaths.EXITROOMS);
            bossRooms = GetRoomsFromTextFile(FilePaths.BOSSROOMS);
            GetRandomRoom(town);
            Character character = campaign.PlayerCharacters.FirstOrDefault();

            if (character != null)
            {
                return true;
            }
            else
            {
                RoomManagerUI.NoPlayerFound();
                return false;
            }
        }

        public static void SpawnPlayer(Campaign campaign)
        {
            int desiredPlayerCount = campaign.PlayerCharacters.Count;
            int playerCount = 0;

            // Iterate through the room layout
            for (int i = 0; i < room.Layout.GetLength(0); i++)
            {
                for (int j = 0; j < room.Layout.GetLength(1); j++)
                {
                    if (room.Layout[i, j] == 'S')
                    {
                        // Update character's X and Y based on 'S' position
                        Character character = campaign.PlayerCharacters[playerCount];
                        character.X = j;
                        character.Y = i;

                        room.Layout[i, j] = ' ';

                        playerCount++;

                        if (playerCount >= desiredPlayerCount)
                        {
                            // Replace all remaining 'S' occurrences with spaces
                            for (int m = i; m < room.Layout.GetLength(0); m++)
                            {
                                for (int n = 0; n < room.Layout.GetLength(1); n++)
                                {
                                    if (room.Layout[m, n] == 'S')
                                    {
                                        room.Layout[m, n] = ' ';
                                    }
                                }
                            }
                            return;
                        }
                    }
                }
            }
            RoomManagerUI.PlayerSpawnError(playerCount);
            return;
        }

        public static List<Characters.Action> GetListAvailablePlayerActions(Campaign campaign, int availableMovementSpaces)
        {
            //check [character.x, character.y] ++ -- room.Layout
            int playerX = campaign.PlayerCharacters[campaign.ActivePlayer].X;
            int playerY = campaign.PlayerCharacters[campaign.ActivePlayer].Y;
            List<Characters.Action> availableActions = new List<Characters.Action>();
            bool moveAdded = false;
            int attackRange = campaign.PlayerCharacters[campaign.ActivePlayer].Weapon.AttackRange;
            if (campaign.CombatParticipants.Count > campaign.PlayerCount)
            {
                for (int checkX = playerX - attackRange; checkX <= playerX + attackRange; checkX++)
                {
                    for (int checkY = playerY - attackRange; checkY <= playerY + attackRange; checkY++)
                    {
                        for (int i = 0; i < campaign.CombatParticipants.Count; i++)
                        {
                            if (campaign.CombatParticipants[i].X == checkX && campaign.CombatParticipants[i].Y == checkY)
                            {
                                if (campaign.CombatParticipants[i].Identifier == Identifier.Monster)
                                {
                                    availableActions.Add(Characters.Action.Attack);
                                }
                            }
                        }
                    }
                }
            }

            for (int checkX = playerX - 1; checkX <= playerX + 1; checkX++)
            {
                for (int checkY = playerY - 1; checkY <= playerY + 1; checkY++)
                {
                    if (checkX == playerX && checkY == playerY)
                    {
                        // Skip the current position (character's position)
                        continue;
                    }
                    switch (room.Layout[checkY, checkX])
                    {
                        case ' ':
                            if (!moveAdded)  // Check if move option hasn't been added yet
                            {
                                if (availableMovementSpaces > 0)
                                {
                                    availableActions.Add(Characters.Action.Move);
                                }
                                if (campaign.PlayerCharacters[campaign.ActivePlayer].ActionsTaken <
                                    campaign.PlayerCharacters[campaign.ActivePlayer].MaxActions)
                                {
                                    availableActions.Add(Characters.Action.RollToMove);
                                }
                                moveAdded = true;  // Set the flag to true after adding move option to prevent duplicates
                            }
                            break;
                        case 'C':
                            availableActions.Add(Characters.Action.SearchChest);
                            break;

                        default:

                            break;
                    }
                }
            }





            return availableActions;

        }

        /// <summary>
        /// Handles player movement and actions
        /// w = move up, a = move left, s = move down, d = move right
        /// t = search for traps, f = search for treasure v = attack
        /// </summary>
        /// <param name="keyInfo"></param>
        public static PlayerAction HandlePlayerActions(ConsoleKeyInfo keyInfo, Campaign campaign,
            List<Characters.Action> availableActions)
        {
            PlayerAction action = new PlayerAction();
            int activePlayer = campaign.ActivePlayer;
            int currentX = campaign.PlayerCharacters[activePlayer].X;
            int currentY = campaign.PlayerCharacters[activePlayer].Y;
            bool move = false;
            bool canDoAction = false;
            bool monsterPresent = false;
            bool playerSearched = false;
            bool playerAttacked = false;
            bool endTurn = false;
            int roll = 0;
           

            
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    // Move up logic
                    campaign.PlayerCharacters[activePlayer].AvailableMovement = TryMovePlayer(campaign, campaign.PlayerCharacters[activePlayer], currentX, currentY - 1, campaign.PlayerCharacters[activePlayer].AvailableMovement);
                    move = true;
                    break;

                case ConsoleKey.A:
                    // Move left logic
                    campaign.PlayerCharacters[activePlayer].AvailableMovement = TryMovePlayer(campaign, campaign.PlayerCharacters[activePlayer], currentX - 1, currentY, campaign.PlayerCharacters[activePlayer].AvailableMovement);
                    move = true;
                    break;

                case ConsoleKey.S:
                    // Move down logic
                    campaign.PlayerCharacters[activePlayer].AvailableMovement = TryMovePlayer(campaign, campaign.PlayerCharacters[activePlayer], currentX, currentY + 1, campaign.PlayerCharacters[activePlayer].AvailableMovement);
                    move = true;
                    break;

                case ConsoleKey.D:
                    // Move right logic
                    campaign.PlayerCharacters[activePlayer].AvailableMovement = TryMovePlayer(campaign, campaign.PlayerCharacters[activePlayer], currentX + 1, currentY, campaign.PlayerCharacters[activePlayer].AvailableMovement);
                    move = true;
                    break;

                case ConsoleKey.T:
                    // Search for traps logic
                    canDoAction = AvailableActionCheck(campaign, activePlayer);
                    if (canDoAction)
                    {
                        trapsSearched = true;
                        campaign.PlayerCharacters[activePlayer].ActionsTaken++;
                    }
                    break;

                case ConsoleKey.F:
                    // Search for treasure logic
                    canDoAction = AvailableActionCheck(campaign, activePlayer);

                    if (canDoAction)
                    {
                        if (campaign.CombatParticipants.Count > campaign.PlayerCharacters.Count)
                        {
                            monsterPresent = true;
                        }
                        else
                        {
                            if (roomSearched == false)
                            {
                                roomSearched = true;
                                playerSearched = true;
                                campaign.PlayerCharacters[activePlayer].ActionsTaken++;
                            }
                            else
                            {
                                playerSearched = false;
                            }
                        }
                    }


                    break;

                case ConsoleKey.V:
                    // combat logic
                    canDoAction = AvailableActionCheck(campaign, activePlayer);
                    if (canDoAction)
                    {

                        if (campaign.CombatParticipants.Count > campaign.PlayerCharacters.Count)
                        {
                            if (availableActions.Contains(Characters.Action.Attack))
                            {
                                playerAttacked = true;
                                IFightable selectedMonster = CombatUI.SelectMonsterFromParticipants(campaign.CombatParticipants);
                                PlayerAttackResult result = Combat.Combat.PlayerAttackAction(ref campaign, activePlayer, selectedMonster);
                                CombatUI.PlayerAttackUI(result);
                                if (result.Dead)
                                {
                                    campaign = Items.Loot.AddNewItem(campaign, activePlayer, false);
                                }
                                campaign.PlayerCharacters[activePlayer].ActionsTaken++;
                            }
                        }
                    }

                    break;
                case ConsoleKey.R:
                    //Roll for movement logic
                    canDoAction = AvailableActionCheck(campaign, activePlayer);
                    if (canDoAction)
                    {
                        roll = Dice.DiceCount("2d4");
                        campaign.PlayerCharacters[activePlayer].AvailableMovement += roll;
                        campaign.PlayerCharacters[activePlayer].ActionsTaken++;
                    }

                    break;
                case ConsoleKey.N:
                    endTurn = true;
                    break;
                default:
                    break;
            }
            RoomManagerUI.PrintPlayerAction(keyInfo, canDoAction, move, monsterPresent, playerSearched, playerAttacked, roll, campaign.PlayerCharacters[activePlayer].AvailableMovement);
            if (endTurn)
            {
                endTurnEarly = RoomManagerUI.EndTurn();
            }
            if (endTurnEarly)
            {
                campaign.PlayerCharacters[activePlayer].AvailableMovement = 0;
            }

            if (playerSearched)
            {
                campaign = Items.Loot.AddNewItem(campaign, activePlayer, true);
            }

            action.Campaign = campaign;
            return action;
        }

        private static bool AvailableActionCheck(Campaign campaign, int i)
        {
            if (campaign.PlayerCharacters[i].ActionsTaken >= 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static BlockedBy CanPlayerMoveThere(Campaign campaign, Character character, int targetX, int targetY, int availableMovementSpaces)
        {
            if (availableMovementSpaces > 0)
            {
                if (IsTargetInBounds(room, campaign, targetX, targetY))
                {
                    for (int i = 0; i < campaign.CombatParticipants.Count; i++)
                    {
                        if (campaign.CombatParticipants[i].X == targetX && campaign.CombatParticipants[i].Y == targetY)
                        {
                            return BlockedBy.Monster;
                        }
                    }
                    switch (room.Layout[targetY, targetX])
                    {

                        case 'C':
                            return BlockedBy.Chest;
                        case 'T':
                            return BlockedBy.Trap;
                        case 'D':
                            return BlockedBy.Door;
                        case 'E':
                            return BlockedBy.NewFloor;
                        case 'K':
                            return BlockedBy.Shop;
                        default:
                            return BlockedBy.None;
                    }
                }
                else
                {
                    return BlockedBy.Wall;
                }
            }
            else
            {
                return BlockedBy.Movement;
            }
        }

        private static int TryMovePlayer(Campaign campaign, Character character, int targetX, int targetY, int availableMovementSpaces)
        {
            bool changeFloorCheck = false;
            BlockedBy blockedBy = new BlockedBy();
            blockedBy = CanPlayerMoveThere(campaign, character, targetX, targetY, availableMovementSpaces);
            switch (blockedBy)
            {
                case BlockedBy.None:
                    character.X = targetX;
                    character.Y = targetY;
                    availableMovementSpaces--;
                    break;
                case BlockedBy.Wall:
                    break;
                case BlockedBy.Door:
                    newRoom = true;
                    campaign.CombatParticipants.RemoveRange(campaign.PlayerCount,
                                campaign.CombatParticipants.Count - campaign.PlayerCount);
                    if (campaign.inTown)
                    {
                        GetRandomRoom(startingRooms);
                    }
                    else
                    {
                        int exitChance = floorLevel * 5 + 5;
                        if (exitChance >= 100)
                        {
                            exitChance = 100;
                        }
                        //creates a chance of an exit rooom spawning
                        int ranNum = Dice.DiceRoll(exitChance);
                        if (ranNum >= exitChance)
                        {
                            GetRandomRoom(exitRooms);
                        }
                        else
                        {
                            GetRandomRoom(mainRooms);
                        }
                    }
                    availableMovementSpaces--;
                    trapsSearched = false;
                    chestFound = false;
                    newRoom = true;
                    playerLocationUpdated = false;
                    break;
                case BlockedBy.NewFloor:
                    changeFloorCheck = true; 
                    break;
                case BlockedBy.Trap:
                    character.X = targetX;
                    character.Y = targetY;
                    //deal damage to player here
                    character.DamageTaken += 1;
                    availableMovementSpaces --;
                    break;
                case BlockedBy.Shop:
                    character = Items.Shop.ShopMain(character);
                    break;
                case BlockedBy.Movement:
                    break;
                case BlockedBy.Monster:
                    break;
                case BlockedBy.Chest:
                    break;
            }
            RoomManagerUI.PrintPlayerCanMove(blockedBy, character);
            if (changeFloorCheck)
            {
                ChangeFloor changeFloor = new ChangeFloor();
                changeFloor = RoomManagerUI.GetFloorChangeConfirmation();
                if (changeFloor.LeaveFloor)
                {
                    if (changeFloor.NextFloor)
                    {
                        floorLevel += 1;
                        if (floorLevel % 5 == 0)
                        {
                            GetRandomRoom(bossRooms);
                            bossRoom = true;
                        }
                        else
                        {
                            GetRandomRoom(startingRooms);
                            bossRoom = false;
                        }
                        chestFound = false;
                        newRoom = true;
                        playerLocationUpdated = false;
                        campaign.inTown = true;
                    }
                    if (changeFloor.LeaveDungeon)
                    {
                        bossRoom = false;
                        floorLevel = 1;
                        GetRandomRoom(town);
                        chestFound = false;
                        newRoom = true;
                        playerLocationUpdated = false;
                        campaign.inTown = true;
                    }
                }
                else
                {
                    character.X = targetX;
                    character.Y = targetY;
                }
            }
            return availableMovementSpaces;
        }

        /// <summary>
        /// checks to make sure the move is valid by checking it is inside the room and not in the space of an object
        /// that can not be 
        /// </summary>
        /// <param name="room"></param>
        /// <param name="campaign"></param>
        /// <param name="targetX"></param>
        /// <param name="targetY"></param>
        /// <returns></returns>
        private static bool IsTargetInBounds(Room room, Campaign campaign, int targetX, int targetY)
        {
            // Check if the target position is within the bounds of the room
            if (targetX >= 0 && targetX < room.Layout.GetLength(1) &&
                targetY >= 0 && targetY < room.Layout.GetLength(0))
            {
                // Check if the target position is not a wall ('#')
                return room.Layout[targetY, targetX] != '#';
            }

            return false;
        }


        /// <summary>
        /// Gets a random number and uses that to select the room that appears
        /// </summary>
        /// <param name="rooms"></param>
        /// <returns></returns>
        private static void GetRandomRoom(List<Room> rooms)
        {
            int randomRoomNumber = Dice.DiceRoll(rooms.Count) - 1;
            room = rooms[randomRoomNumber];
        }

        /// <summary>
        /// seperates the rooms in the text files, using "ROOM" as the divider, then adds them to a list
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns name="rooms"></returns>
        public static List<Room> GetRoomsFromTextFile(string filePath)
        {
            List<Room> rooms = new List<Room>();
            string[] lines = File.ReadAllLines(filePath);

            List<string> currentRoom = new List<string>();
            foreach (string line in lines)
            {
                if (line.Trim().Equals("ROOM"))
                {
                    Room newRoom = CreateRoom(currentRoom);
                    rooms.Add(newRoom);
                    currentRoom.Clear();
                }
                else
                {
                    currentRoom.Add(line);
                }
            }

            return rooms;
        }
        /// <summary>
        /// takes from the l
        /// </summary>
        /// <param name="currentRoom"></param>
        /// <returns></returns>
        private static Room CreateRoom(List<string> currentRoom)
        {
            Room newRoom = new Room();
            if (currentRoom.Count > 0)
            {

                int rows = currentRoom.Count;
                int columns = currentRoom.Max(row => row.Length);

                char[,] layout = new char[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    int currentRowLength = currentRoom[i].Length;


                    for (int j = 0; j < columns; j++)
                    {
                        layout[i, j] = currentRoom[i][j];
                    }
                    for (int j = currentRowLength; j < columns; j++)
                    {
                        layout[i, j] = ' ';
                    }
                }

                newRoom.Layout = layout;
            }
            else
            {
                RoomManagerUI.RoomCreationError();
            }
            return newRoom;
        }


        public static Campaign CheckRoomLayout(Campaign campaign)
        {
            bool monsterSpawned = false;

            for (int z = 0; z < campaign.PlayerCount; z++)
            {
                for (int i = 0; i < room.Layout.GetLength(0); i++)
                {
                    for (int j = 0; j < room.Layout.GetLength(1); j++)
                    {
                        if (newRoom == true)
                        {
                            if (monsterSpawned == false)
                            {

                                campaign = Spawnmonster(campaign);
                                monsterSpawned = true;
                            }
                            if (room.Layout[i, j] == 'C')
                            {
                                roomSearched = false;
                                chestFound = true;
                            }
                            if (chestFound == false)
                            {
                                roomSearched = true;
                            }

                            if (playerLocationUpdated == false)
                            {
                                if (room.Layout[i, j] == 'D')
                                {
                                    switch (FindDoorSide(room, i, j))
                                    {
                                        case DoorSide.Right:
                                            campaign.PlayerCharacters[z].Y = i;
                                            campaign.PlayerCharacters[z].X = j - 1;
                                            break;
                                        case DoorSide.Left:
                                            campaign.PlayerCharacters[z].Y = i;
                                            campaign.PlayerCharacters[z].X = j + 1;
                                            break;
                                        case DoorSide.Bottom:
                                            campaign.PlayerCharacters[z].Y = i - 1;
                                            campaign.PlayerCharacters[z].X = j;
                                            break;
                                        case DoorSide.Top:
                                            campaign.PlayerCharacters[z].Y = i + 1;
                                            campaign.PlayerCharacters[z].X = j;
                                            break;
                                    }
                                    playerLocationUpdated = true;

                                }
                            }
                        }
                    }
                }
                newRoom = false;
            }
            return campaign;
        }
        public static Campaign Spawnmonster(Campaign campaign)
        {

            // Iterate through the room layout
            for (int i = 0; i < room.Layout.GetLength(0); i++)
            {
                for (int j = 0; j < room.Layout.GetLength(1); j++)
                {
                    if (room.Layout[i, j] == 'm')
                    {
                        Monster monster = new();
                        // Update monster's X and Y based on 'm' position
                        if (bossRoom)
                        {
                            monster = GetBossMonster();
                        }
                        else
                        {
                            monster = GetRandomMonster();
                        }

                        monster.X = j;
                        monster.Y = i;
                        campaign.CombatParticipants.Add(monster);
                        campaign.ActiveMonsters.Add(monster);
                    }
                }
            }
            return campaign;
        }

        private static Monster GetBossMonster()
        {
            Type type = typeof(BossMonsterName);
            Array monsterNames = type.GetEnumValues();
            int randomIndex = Dice.DiceRoll(monsterNames.Length);
            BossMonsterName monsterType = (BossMonsterName)monsterNames.GetValue(randomIndex - 1);
            Monster monster = MonsterStats.GetBossMonsterStats(monsterType);
            return monster;
        }

        /// <summary>
        /// Gets a random monster from the monster enum and returns it
        /// </summary>
        /// <returns></returns>
        private static Monster GetRandomMonster()
        {
            Type type = typeof(MonsterName);
            Array monsterNames = type.GetEnumValues();
            int randomIndex = Dice.DiceRoll(monsterNames.Length);
            MonsterName monsterType = (MonsterName)monsterNames.GetValue(randomIndex - 1);
            Monster monster = MonsterStats.GetMonsterStats(monsterType);
            return monster;
        }

        private static DoorSide FindDoorSide(Room room, int i, int j)
        {
            if (j == room.Layout.GetLength(1) - 1)
                return DoorSide.Right;

            if (j == 0)
                return DoorSide.Left;

            if (i == room.Layout.GetLength(0) - 1)
                return DoorSide.Bottom;

            if (i == 0)
                return DoorSide.Top;

            return DoorSide.Right;
        }
        public static void PrintRoomLayout(Campaign campaign)
        {

            for (int i = 0; i < room.Layout.GetLength(0); i++)
            {
                for (int j = 0; j < room.Layout.GetLength(1); j++)
                {
                    Char roomCell = GetRoomCell(i, j, campaign);
                    RoomManagerUI.PrintRoomCell(roomCell);
                }
                Console.WriteLine();
            }

        }



        public static Char GetRoomCell(int i, int j, Campaign campaign)
        {
            Char roomCell = ' ';
            for (int a = 0; a < campaign.CombatParticipants.Count; a++)
            {
                if (i == campaign.CombatParticipants[a].Y && j == campaign.CombatParticipants[a].X)
                {
                    if (campaign.CombatParticipants[a].Identifier == Identifier.Player)
                    {
                        return 'X';
                    }
                    if (campaign.CombatParticipants[a].Identifier == Identifier.Monster)
                    {
                        return 'M';
                    }
                }
            }

            switch (room.Layout[i, j])
            {
                case 'T':
                    if (trapsSearched)
                    {
                        roomCell = room.Layout[i, j];
                    }
                    else
                    {
                        roomCell = ' ';
                    }
                    break;
                case 'm':
                    roomCell = ' ';
                    break;
                default:
                    roomCell = room.Layout[i, j];
                    break;
            }
            return roomCell;
        }

        public static Campaign PlayersTurn(Campaign campaign, int i)
        {
            if (playerDead)
            {
                campaign.CombatParticipants.Clear();
                campaign.PlayerCharacters.Clear();
                return campaign;
            }
            List<Characters.Action> availableActions = GetListAvailablePlayerActions(campaign, campaign.PlayerCharacters[i].AvailableMovement);
            RoomManagerUI.DisplayAvailableActions(availableActions, campaign);

            ConsoleKeyInfo keyInfo;

            while ((keyInfo = Console.ReadKey()).Key != ConsoleKey.Escape)
            {
                if (playerDead)
                {
                    campaign.CombatParticipants.Clear();
                    campaign.PlayerCharacters.Clear();
                    return campaign;
                }
                PlayerAction action;
                action = HandlePlayerActions(keyInfo, campaign, availableActions);
                campaign = action.Campaign;
                if (endTurnEarly)
                {
                    campaign.PlayerCharacters[i].ActionsTaken = 0;
                    endTurnEarly = false;
                    break;
                }
                if (campaign.inTown == true && playerLocationUpdated == false)
                {
                    SpawnPlayer(campaign);
                    playerLocationUpdated = true;
                    campaign.inTown = false;
                }
                campaign = CheckRoomLayout(campaign);
                PrintRoomLayout(campaign);
                availableActions = GetListAvailablePlayerActions(campaign, campaign.PlayerCharacters[i].AvailableMovement);

                if (campaign.PlayerCharacters[i].ActionsTaken >= campaign.PlayerCharacters[i].MaxActions &&
                    campaign.PlayerCharacters[i].AvailableMovement <= 0)
                {
                    campaign.PlayerCharacters[i].ActionsTaken = 0;
                    break;
                }
                RoomManagerUI.DisplayAvailableActions(availableActions, campaign);

            }
            return campaign;
        }

        //TODO make it so that player death can be done on a multiplayer game
        public static void PlayerDeath()
        {
            playerDead = true;
        }

        internal static void MonstersTurn(Campaign campaign, int i)
        {
            UI.MonsterTurnStart();
            int a = i - campaign.PlayerCount;
            int target = FindTarget(campaign, a);
            MoveToTarget(campaign, target, i);
            PrintRoomLayout(campaign);
            MonsterAttackResult result = Combat.Combat.MonsterAttack(ref campaign, target, i);
            Combat.CombatUI.MonsterAttackUI(result);
        }

        /// <summary>
        /// moves the monster to the targeted player
        /// </summary>
        /// <param name="campaign"></param>
        /// <param name="target"></param>
        /// <param name="i"></param>
        private static void MoveToTarget(Campaign campaign, int target, int i)
        {
            int targetX = campaign.CombatParticipants[target].X;
            int targetY = campaign.CombatParticipants[target].Y;

            int currentX = campaign.CombatParticipants[i].X;
            int currentY = campaign.CombatParticipants[i].Y;

            bool pathClear = true;

            for (int moves = 0; moves < campaign.CombatParticipants[i].Speed; moves++)
            {
                //checks if the monster is adjacent to target player
                if ((currentY == targetY && Math.Abs(currentX - targetX) == 1) ||
                    (currentX == targetX && Math.Abs(currentY - targetY) == 1))
                {
                    break;
                }
                switch (currentX.CompareTo(targetX))
                {
                    case 0:
                        switch (currentY.CompareTo(targetY))
                        {
                            case 0:
                                break;
                            case 1:
                                pathClear = TryMoveMonster(campaign, i, currentX, currentY - 1);
                                if (pathClear)
                                {
                                    currentY -= 1;
                                }

                                break;
                            case -1:
                                pathClear = TryMoveMonster(campaign, i, currentX, currentY + 1);
                                if (pathClear)
                                {
                                    currentY += 1;
                                }

                                break;
                        }
                        break;
                    case 1:
                        pathClear = TryMoveMonster(campaign, i, currentX - 1, currentY);
                        if (pathClear)
                        {
                            currentX -= 1;
                        }

                        break;
                    case -1:
                        pathClear = TryMoveMonster(campaign, i, currentX + 1, currentY);
                        if (pathClear)
                        {
                            currentX += 1;
                        }
                        break;
                }

            }

            campaign.CombatParticipants[i].X = currentX;
            campaign.CombatParticipants[i].Y = currentY;
        }

        private static bool TryMoveMonster(Campaign campaign, int i, int targetX, int targetY)
        {
            bool clear = true;
            switch (room.Layout[targetY, targetX])
            {

                case 'C':
                    clear = false;
                    break;
                case 'D':
                    clear = false;
                    break;
                case 'M':
                    clear = false;
                    break;
                case '#':
                    clear = false;
                    break;
                default:
                    clear = true;
                    break;
            }
            for (int a = 0; a < campaign.CombatParticipants.Count; a++)
            {
                if (campaign.CombatParticipants[a].X == targetX && campaign.CombatParticipants[a].Y == targetY)
                {
                    clear = false;
                }
            }


            return clear;
        }

        /// <summary>
        /// finds the nearest player 
        /// </summary>
        /// <param name="campaign"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        private static int FindTarget(Campaign campaign, int a)
        {
            int monsterX = campaign.ActiveMonsters[a].X;
            int monsterY = campaign.ActiveMonsters[a].Y;

            for (int count = 1; count <= 10; count++)
            {
                for (int checkX = monsterX - count; checkX <= monsterX + count; checkX++)
                {
                    for (int checkY = monsterY - count; checkY <= monsterY + count; checkY++)
                    {
                        if (checkX == monsterX && checkY == monsterY)
                        {
                            // Skip the current position (monsters position)
                            continue;
                        }
                        for (int b = 0; b < campaign.CombatParticipants.Count; b++)
                        {
                            var target = campaign.CombatParticipants[b];

                            if (checkX == target.X && checkY == target.Y)
                            {
                                if (target.Identifier == Identifier.Player)
                                {
                                    return b;
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }
    }
}
