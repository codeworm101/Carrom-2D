# Carrom-2D
Carrom Game Made In Unity

It is a single player Carrom game in which you play against an AI 

It contains:-

1)GameManager - Manages the unique turn based system of the game which waits until the user is finished playing his turn and checks if any coins have been pocketed and adds them to the score

2)StrikerController - Manages the User Striker responsible for shooting the coins it points an arrow towards the direction the user is trying to hit and creates a field showing the power of the strike

3)CarromAI - Its a simple AI implementation which takes note of all the coins currently on board and calculates their position after which it chooses a coin it prefers and shoots

4)SoundManager - It Manages all the Background music strike shots and coin hitting the striker
