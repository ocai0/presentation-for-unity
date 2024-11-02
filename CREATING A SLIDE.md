- Abrir o projeto
- Na aba project, copie o arquivo Slide Template e renomeie o arquivo
- Selecione o arquivo que você copiou e clique, na aba Hierarchy, o objeto GameManager, nele defina o indice do slide

- Para adicionar letras ao slide:
 - Na aba Hierarchy, selecione o item 'Grid', e selecione o sub-item Pellets
 - Quando selecionar o item, na aba Scene, procure um ícone que se assemelha a vários quadradinhos roxos, selecione ela
 - Agora você pode desenhar as letras na cena

- Para adicionar as cápsulas e super-cápsulas ao slide:
 - Na aba Hierarchy, selecione o item 'Grid', e selecione o sub-item Pellets
 - Quando selecionar o item, na aba Scene, procure um ícone que se assemelha a vários quadradinhos roxos, selecione ela
 - Cápsulas e super-cápsulas são itens que não possuem ícone no tilemap, mas estão logo acima da esfera verde, basta selecionar e usar na cena

- Para adicionar paredes
 - Na aba Hierarchy, selecione o item 'Grid', e selecione o sub-item Walls
 - Quando selecionar o item, na aba Scene, procure um ícone que se assemelha a vários quadradinhos roxos, selecione ela
 - Agora você pode desenhar as paredes na cena

- Para adicionar o Pacman
 - Na aba project, na pasta prefabs, clique e arraste o item Pacman na cena ou na aba Hierarchy

- Para adicionar Fantasmas
 - Na aba project, na pasta prefabs, clique e arraste o item do Fantasma que deseja colocar na cena ou na aba Hierarchy
 - O fantasma branco é o arquivo base para fazer todos os outros e não deve ser usado
 - Para os fantasmas andarem, você precisa adicionar 'nodes' na cena

- Para adicionar Nodes
 - Na aba Hierarchy, selecione o item 'Grid', e selecione o sub-item Nodes
 - Quando selecionar o item, na aba Scene, procure um ícone que se assemelha a vários quadradinhos roxos, selecione ela
 - O 'node' é a esfera verde, usada pelos fantasmas para definir para onde vão se locomover. Basta colocar nodes que quando o fantasma colidir com ela irá mudar a direção deles

- Fazendo um caminho predefinido para o pacman
 - Na aba project, na pasta prefabs, clique e arraste o item Node na cena ou na aba Hierarchy
 - Para facilitar o gerenciamento, na aba Hierarchy arraste o elemento node para dentro do item Grid/Nodes
 - Clique em Node e na aba inspector, no submenu Node (Script), defina os valores X e Y do item 'Force Pacman on Direction'
 - Qualquer valor diferente de (0, 0) estará definindo um eixo para o pacman 

- Quando roda o projeto tem dois modos, o SLIDE e o GAME.
 - Para ir do modo SLIDE para o GAME, aperte o enter. Aqui você vai ter o controle do pacman, as setas do teclado controlam o pacman
 - Para ir do modo GAME para o SLIDE, aperte o esc. Aqui o jogo fica no modo piloto automatico, e as setas do teclado passam os slides