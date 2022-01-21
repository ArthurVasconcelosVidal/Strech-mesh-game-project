# Stretch mesh game prototype

###### Recursos:
    
  - **Cinemachine:** Implementado o modulo de camera da unity (Cinemachine)
  - **Backhand:**  Foi feita utilizando o sistema de Animation Rigging da unity
  - **Movimentação Backhand:** A movimentação da backhand utiliza o comportamento de Chain IK para rastrear onde a Backhand deve apontar e permanecer, a movimentação é feita pela mudança de posição do ponto de ferencia utilizado pelo Chain IK
  - **Sistema de distorção de mesh:** Para distorção de mesh foi utilizado um shader externo (https://github.com/bzgeb/UnitySoftbodyDeformation) -Thank you very much bzgeb-
  - **Movimentação Backhand dentro do limite estabelecido:** A movimentação da backhand é limitada dentro do tamanho da backhand, é possivel aumentar e diminuir o tamanho atualizando os valores  
  - **Rotação e orientação da BackHand:** a movimentação é feita levando em consideração a direção atual da câmera e a posição da mão é resetada quando não esta sendo usada, ajudando o jogador a não se perder enquanto usa
  - **Tradução do shader de distorção para shader graph:** Foi produzida uma transcrição do shader standard para Shader graph, a tradução funciona mas apresenta problemas na renderização (A mesh desaparece e reaparece sem lógica aparente)


###### Resources:

  - **Cinemachine:** Implemented the Unity camera module (Cinemachine)
  - **Backhand:** It was made using the Unity Animation Rigging system
  - **Movement Backhand:** The movement of the Backhand use the the behavior of the IKchain for determination of the position and orientation of the Backhand, the movement of the Backhand are made by the postion of an transform.
  - **Mesh distortion system:** For mesh distortion an external shader was used (https://github.com/bzgeb/UnitySoftbodyDeformation) -Thank you very much bzgeb-
  - **Hand limit movement:** the space of moviment for the Backhand increase within bBackhand size limitation, its possible increand or decrease the hand space limitation by changing the hand lenght
  - **Rotate and Rotate BackHand:** The Backhand movimentation uses the camera look direction, making more easy for the player knows how to move the Backhand
  - **Translation of the distortion shader for shader graph:** It was developed an translation into a shader graph but the sahder procude rendering problems (The mesh disappear and reappear without aparently logic)
 
## Youtube Video

[![PlaceHolder](http://img.youtube.com/vi/CCIfc7-5HRg/0.jpg)](https://youtu.be/CCIfc7-5HRg "PLACE HOLDER")
- Link: PLACE HOLDER

## Agradecimentos especiais / Special thanks
- bzgeb (Distortion standard shader):
https://bronsonzgeb.com/index.php/2021/07/10/mesh-deformation-in-unity/
