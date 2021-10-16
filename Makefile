TARGET = tsim
CXX = clang++-12
OBJS = main.o
CXXFLAGS = -Wall -Wextra -std=c++20 -fsanitize=leak 
LDFLAGS = 


DEBUG = -g -fsanitize=address -Wfloat-equal -O0

.PHONY: all
all: tsim Makefile

.PHONY: clean
clean:
	rm -rf *.o

.PHONY: debug
debug: Makefile
	$(CXX) $(CXXFLAGS) $(DEBUG) .cpp


tsim: $(OBJS) Makefile
	$(CXX) $(LDFLAGS) -o tsim $<

%.o: %.cpp Makefile
	$(CXX) $(CXXFLAGS) -O2 -c $<
