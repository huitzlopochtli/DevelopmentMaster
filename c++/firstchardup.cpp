#include <iostream>
#include <fstream>
#include <vector>
#include <cstdarg>
#include <string>
#include <cstdio>
#include <cctype>
#include <cmath>
#include <ctime>
#include <queue>
#include <map>
#include <set>
#include <algorithm>
#include <climits>
#include <sstream>
#include <numeric>
#include <iterator>
#include <iomanip>
#include <utility>
#include <stack>
#include <functional>
#include <deque>
#include <complex>
#include <bitset>
#include <list>
#include <array>
#include <regex>
#include <random>
#include <unordered_set>
#include <unordered_map>
#include <atomic>
#include <thread>
#include <mutex>
#include <condition_variable>
#include <future>

using namespace std;

char firstNotRepeatingCharacter(string s) {
    map<char, int> dic;

    for(int i=0; i<s.length(); i++)
    {
        auto itr = dic.find(s[i]);
        if(itr == dic.end())
            dic.insert(pair<char,int>(s[i],1));
        else {
            itr->second++;
        }
    }

}


int main()
{

    string a = "abcd";

    char = firstNotRepeatingCharacter(a);
    retirn 0;
}
