CC = g++
PROJECT = output
SRC = Program.cs
LIBS = `pkg-config --cflags --libs opencv`
$(PROJECT) : $(SRC)
	$(CC) $(SRC) -o $(PROJECT) $(LIBS)
	./$(PROJECT)
