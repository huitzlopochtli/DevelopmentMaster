#include <iostream>
#include <string>
using namespace std;

string toLowerCase(string str)
{
  for(int i=0; i<str.length(); i++)
  {
    if(str[i] >= 65 && str[i] <= 90)
      str[i] = str[i] + 32;
  }

  return str;
}

int main(int argc, char *argv[]) {
  // このコードは標準入力と標準出力を用いたサンプルコードです。
  // このコードは好きなように編集・削除してもらって構いません。
  // ---
  // This is a sample code to use stdin and stdout.
  // Edit and remove this code as you like.

  string line;
  int index = 1;
  while (!cin.eof()) {
    getline(cin, line);
    line = toLowerCase(line);
    cout << "Hello " << line << "!"<< endl;
  }
  return 0;
}
