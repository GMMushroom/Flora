# Flora
Flora is my multimedia majorwork project. It's a 2D Fighter akin to Street Fighter or Tough Love Arena. Currently, the game has only two of the same character, Ray, controlled by P1 and P2. There are currently three attack buttons, while a fourth 'special' attack will be implemented later in the future.
 
 P1 Controls:
 Left and Right: A & D
 Crouch: S
 Jump: W
 Block: Q
 A Button/Light Attack: F
 B Button/Medium Attack: G
 C Button/Heavy Attack: H
 
 P2 Controls:
 Left and Right: Left & Right Keys
 Crouch: Down Key
 Jump: Up Key
 Block: " ' "
 A Button/Light Attack: ","
 B Button/Medium Attack: "."
 C Button/Heavy Attack: "/"
 
 Current Major Issue:
 Whenever a player blocks, they recieve more damage than they should have instead of taking none. They way I've set it up according to the tutorial I'm watching, by using code, we can disable the colliders that would normally register damage according to the player's current animator state. Like so:
 
 //Disable RigidBody2D and Collider2D when Blocking
        if (Player1Layer0.IsTag("Blocking"))
        {
            rb.isKinematic = true;
            CapsuleCollider1.enabled = false;
            CapsuleCollider2.enabled = false;
        }
        else
        {
            CapsuleCollider1.enabled = true;
            CapsuleCollider2.enabled = true;
            rb.isKinematic = false;
        }

The code works, just not as intended. Instead of disabling the colliders, the colliders instead flicker on and off, but that doesn't show in unity. So for almost every frame an attack is active, the game registers each frame as an individual attack and thus deal more damage than if the player had just stood still. This problem seems to only affect blocking while standing. If the player is blocking while crouching, the code works as intended. So it might not be a problem with the code, but with the 'Standing Block' animation?
