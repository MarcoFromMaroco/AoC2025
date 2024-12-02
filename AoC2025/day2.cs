﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC2025
{
    internal class day2
    {
        static bool secondStep = true;

        internal static void Go(bool workOnRealData)
        {
            int safeReports = 0;
            var input = workOnRealData ? realInput.Split(Environment.NewLine) : testInput.Split(Environment.NewLine);
            foreach (var item in input)
            {
                bool isSafe = true;
                var nums = item.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x=>int.Parse(x)).ToList();
               
                isSafe = CheckIt(nums);
                if (!isSafe && secondStep)
                {
                    for (int i = 0; i < nums.Count; i++)
                    {
                        isSafe = CheckIt(nums.Where((x, j) => j != i).ToList());
                        if (isSafe)
                            break;
                    }
                }

                if (isSafe)
                    safeReports++;
            }
            Console.WriteLine($"Safe reports {safeReports}");
        }

        private static bool CheckIt(List<int> nums)
        {
            bool isSafe = true;
            int? previous = null;
            bool? isIncreasing = null;
            bool canSkipToNextOne = secondStep;
            int step = 0;
            //foreach (var current in item.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)))
            for (int i = 0; i < nums.Count; i++)
            {
                var current = nums[i];
                step++;
                if (previous != null)
                {
                    if (isIncreasing == null)
                        isIncreasing = previous < current;

                    if ((bool)isIncreasing && previous > current)
                    {
                        isSafe = false;
                        //break;
                    }
                    if (!(bool)isIncreasing && previous < current)
                    {
                        isSafe = false;
                        //break;
                    }
                    int diff = Math.Abs((int)previous - current);
                    if (diff == 0 || diff > 3)
                    {
                        isSafe = false;
                        //break;
                    }
                }
                previous = current;
            }
            return isSafe;
        }

        static string testInput =
            @"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9";
        static string realInput =
    @"58 59 62 63 64 63
71 72 74 76 78 80 82 82
26 29 32 34 35 39
9 11 14 17 19 20 21 26
89 92 95 93 94 97 98
35 37 40 41 43 42 39
89 91 94 96 97 99 98 98
85 86 83 84 85 86 90
46 48 50 52 49 52 59
56 58 58 60 62
77 79 82 83 86 87 87 85
5 6 9 9 12 15 15
78 80 80 82 83 84 88
78 81 83 85 86 86 88 94
80 81 83 84 88 91
10 13 16 17 21 19
14 16 19 22 23 24 28 28
11 12 14 17 19 23 27
68 71 72 73 76 80 86
78 79 82 87 88
53 56 58 64 62
44 46 49 56 56
29 31 32 33 36 37 43 47
38 41 43 44 49 50 53 59
28 27 30 32 35 36 38
48 46 47 50 53 50
23 22 25 28 28
16 15 17 19 21 23 27
34 32 33 35 37 40 43 48
83 80 81 82 79 82 83
68 67 65 66 68 70 69
86 84 86 83 84 85 85
65 64 67 68 66 70
40 39 42 45 43 49
32 29 30 30 32 34 35
93 90 90 92 95 97 94
17 15 16 18 20 20 20
82 81 84 84 86 90
71 69 72 73 75 76 76 83
12 11 15 16 18
75 73 77 78 77
10 8 12 13 13
25 23 26 30 32 34 38
10 7 11 12 13 15 18 25
41 39 41 44 47 52 53 55
22 19 26 28 26
54 53 55 62 62
31 30 31 38 42
63 60 62 67 72
49 49 52 55 58 60 62
59 59 60 61 62 64 62
19 19 20 22 22
81 81 82 84 88
17 17 18 19 21 23 30
9 9 10 12 9 11 14
59 59 60 63 61 60
68 68 67 68 70 70
10 10 13 10 13 16 19 23
17 17 19 21 24 23 26 31
68 68 70 70 73 75 77 80
58 58 61 61 60
64 64 66 67 70 72 72 72
82 82 82 84 85 87 91
79 79 79 82 89
31 31 35 36 39
39 39 40 44 41
44 44 45 49 52 53 53
42 42 43 47 49 53
6 6 7 10 14 15 22
17 17 18 23 24 26 29
71 71 73 76 81 82 81
1 1 3 9 12 12
26 26 27 28 29 30 37 41
79 79 80 85 86 93
69 73 75 78 80 81
44 48 49 50 47
21 25 27 30 33 36 39 39
52 56 59 62 65 67 71
7 11 12 13 14 21
65 69 72 75 78 77 80
53 57 60 63 64 66 65 64
85 89 91 94 96 94 94
80 84 81 83 85 89
56 60 61 63 64 61 63 68
42 46 47 50 50 52 55
85 89 90 90 87
71 75 77 80 81 81 81
52 56 57 58 58 61 62 66
69 73 76 76 81
22 26 28 30 34 37 40
68 72 76 77 79 77
43 47 48 51 55 56 56
49 53 55 56 60 61 65
30 34 38 39 42 43 45 50
41 45 51 54 55 57
24 28 29 36 38 37
45 49 54 56 56
15 19 25 26 29 31 35
59 63 64 70 75
75 80 83 85 86 87 88 89
32 39 41 42 40
35 41 44 46 49 52 54 54
13 20 23 24 26 30
16 21 22 23 24 31
42 48 50 51 48 50
16 21 20 22 24 23
32 39 40 37 38 40 43 43
4 9 12 14 15 17 16 20
41 46 48 50 49 54
64 71 72 75 76 77 77 79
66 72 73 73 75 73
63 68 69 69 72 72
5 12 15 15 18 22
63 68 70 73 73 75 76 81
52 57 58 62 64 67
15 21 23 27 28 30 29
35 42 43 46 50 50
68 75 77 78 82 85 88 92
31 38 42 45 51
7 14 16 17 23 26 27
41 48 51 56 58 57
73 80 86 87 90 90
5 11 13 20 24
68 74 77 80 87 92
94 92 91 90 88 91
42 39 38 37 34 34
77 74 71 69 67 66 62
76 75 73 72 70 67 65 59
27 25 24 27 26 24 22
87 86 89 86 89
62 61 62 61 60 58 56 56
10 7 6 7 3
34 33 31 34 31 29 22
27 26 26 24 23 22 19
41 38 38 36 37
86 83 83 81 81
16 15 15 14 13 10 7 3
47 46 46 45 38
61 58 57 56 54 50 48
42 41 37 36 37
70 68 64 62 62
15 12 11 9 5 1
76 73 69 68 63
89 87 86 80 78 77 75
92 90 88 85 82 76 78
85 82 79 72 71 68 65 65
92 91 88 83 80 78 74
60 58 57 56 54 48 42
38 40 39 38 37 34
73 76 73 72 75
44 47 45 43 40 38 36 36
40 43 40 39 35
27 29 26 25 22 20 15
21 24 21 22 20
5 7 6 7 4 3 6
82 83 82 79 76 79 79
25 27 30 28 24
81 83 81 84 79
87 89 89 86 84 81 80 77
36 38 38 35 36
37 40 38 38 38
84 85 82 81 81 77
16 17 14 13 13 6
36 38 34 32 30 28
13 14 13 9 6 5 6
32 33 31 27 27
33 35 32 28 24
95 96 93 89 86 83 76
56 59 58 51 48 46 45
55 56 54 47 44 47
25 26 24 21 15 15
35 37 30 27 23
93 96 95 88 86 79
16 16 13 11 9 6 3 2
65 65 63 61 64
58 58 56 54 52 50 50
78 78 76 75 72 69 65
80 80 79 76 75 72 66
49 49 50 48 45 42
57 57 54 52 54 57
85 85 82 85 82 79 76 76
52 52 50 49 48 50 46
34 34 32 35 30
55 55 52 49 49 47
94 94 93 93 96
16 16 16 14 12 12
87 87 87 84 82 80 79 75
46 46 43 43 40 33
64 64 60 58 56 55 53 51
88 88 85 83 79 77 78
33 33 29 28 27 27
49 49 47 46 42 38
88 88 85 81 80 75
13 13 10 4 1
80 80 77 76 74 68 67 70
88 88 81 79 76 76
65 65 63 57 53
41 41 36 35 32 29 22
77 73 72 71 70 69 67 65
79 75 72 69 68 71
99 95 93 92 91 90 87 87
18 14 13 10 7 3
72 68 65 63 56
70 66 64 62 59 61 58
78 74 73 76 73 70 67 69
68 64 67 65 65
57 53 50 48 51 47
13 9 12 11 9 4
51 47 44 44 41
81 77 75 75 76
51 47 46 46 46
21 17 14 11 9 9 8 4
80 76 74 73 73 72 71 66
22 18 16 12 11 9
22 18 16 12 10 12
22 18 14 12 11 10 8 8
31 27 24 20 16
48 44 43 42 38 31
30 26 19 17 16
39 35 28 26 23 25
66 62 56 53 52 51 51
25 21 14 12 11 7
82 78 75 73 71 65 58
36 29 27 25 24 22 21 18
34 29 27 26 23 20 22
74 68 67 64 64
75 70 67 66 63 60 56
98 91 89 86 84 83 76
50 45 48 45 43 41 39
89 84 86 83 81 79 77 79
66 60 63 61 59 59
44 38 37 38 34
53 47 45 46 41
14 8 7 7 6 5 2
36 30 27 27 24 27
23 16 16 13 11 11
55 48 48 47 43
83 78 77 77 75 70
37 30 27 25 21 19 18 15
81 74 73 69 67 65 63 66
57 51 49 48 47 46 42 42
62 56 53 50 46 43 40 36
49 42 38 35 29
97 92 89 84 81
79 72 69 68 66 60 62
87 82 79 78 71 71
75 70 69 64 62 61 57
84 79 76 71 68 62
17 19 20 21 22 20
71 74 75 78 81 81
58 60 62 63 65 69
21 23 24 26 28 34
70 72 74 76 78 80 78 80
33 35 34 36 37 35
18 20 23 24 22 25 28 28
88 91 94 92 96
7 9 11 8 14
63 65 66 68 68 69 71
20 23 24 27 27 28 26
61 62 63 64 64 64
66 68 70 70 74
17 19 20 20 22 25 28 34
7 10 14 17 20 22
13 15 17 21 23 22
8 9 13 15 16 19 19
73 74 76 79 82 84 88 92
69 71 73 75 79 81 83 88
63 64 66 69 76 78 80 83
76 79 86 88 91 94 91
43 45 46 47 49 52 58 58
41 42 44 46 48 53 54 58
76 77 79 86 88 90 96
25 24 25 27 30 32
6 3 5 8 6
91 89 90 92 92
25 22 24 26 29 32 36
74 71 74 76 78 84
50 49 51 50 53 55
62 61 59 61 60
82 79 80 77 78 81 83 83
93 92 90 91 93 97
88 85 86 85 88 95
29 26 27 30 30 32
24 23 23 24 27 26
33 31 31 34 35 35
89 88 89 89 93
78 75 75 77 79 82 88
45 44 46 50 52 53 55
44 41 45 47 48 46
49 48 52 55 55
69 67 70 73 74 78 82
16 15 19 21 28
11 9 11 17 19 22 25 28
44 42 47 49 46
60 59 64 65 65
42 40 46 49 51 54 58
8 6 9 10 12 13 19 25
53 53 55 56 59 62 63
13 13 16 19 18
4 4 6 9 12 15 17 17
17 17 20 21 22 26
14 14 15 17 20 23 29
16 16 18 20 21 23 21 24
80 80 83 84 81 79
2 2 3 4 3 5 7 7
94 94 95 96 97 98 95 99
3 3 2 5 6 8 13
44 44 47 47 50 51
10 10 13 13 15 13
10 10 10 12 14 14
64 64 66 66 67 71
37 37 38 40 40 43 44 51
65 65 68 71 74 78 79
21 21 23 27 28 31 29
1 1 5 6 9 9
20 20 22 26 29 31 35
81 81 85 86 88 94
17 17 18 23 26 28 30 33
62 62 68 70 69
35 35 36 39 40 46 46
47 47 50 57 59 63
16 16 18 24 29
3 7 9 12 15 17 19 22
34 38 40 43 41
29 33 36 39 39
47 51 52 54 56 57 61
23 27 28 30 32 37
9 13 16 14 15 16 17 20
86 90 88 90 91 89
83 87 84 86 87 87
42 46 44 47 49 53
28 32 30 31 38
2 6 6 9 10 11 13 15
34 38 40 41 42 42 39
19 23 25 27 29 29 29
1 5 6 6 10
5 9 10 13 13 14 16 22
8 12 13 17 20
72 76 78 82 80
11 15 16 20 22 25 25
4 8 11 15 19
5 9 13 16 22
75 79 81 82 88 90 92
80 84 86 91 89
77 81 82 84 90 93 96 96
9 13 16 17 18 24 28
10 14 16 22 27
78 85 88 90 92 94 96 98
32 37 38 41 39
48 54 56 58 58
22 28 30 32 36
23 30 32 34 35 37 40 46
48 55 58 57 59
11 18 21 22 19 21 20
59 64 67 70 69 69
47 54 56 59 62 65 63 67
29 36 37 38 35 42
57 62 64 64 65 66
43 50 51 54 54 56 54
12 19 19 20 20
48 54 56 56 60
38 44 45 45 48 54
56 62 66 67 70 72
64 69 70 73 76 80 82 80
53 59 63 64 64
53 58 60 64 68
4 11 15 17 22
34 41 43 50 53 56
39 46 48 50 51 54 60 59
35 42 47 48 49 49
75 81 84 89 93
31 36 38 40 47 52
21 19 18 17 16 13 14
73 70 67 66 66
74 73 72 70 69 65
37 36 33 32 26
54 53 52 49 48 51 50 48
22 21 20 17 15 12 14 15
66 64 61 64 61 58 55 55
89 88 91 90 87 86 85 81
57 56 53 50 51 45
32 31 28 28 26
51 48 45 45 43 44
98 95 94 94 94
16 13 13 10 6
57 54 51 48 46 46 41
60 57 54 51 47 46 44
92 90 87 84 80 81
15 13 12 8 5 3 2 2
83 82 79 78 77 76 72 68
62 59 56 54 50 43
84 82 81 78 73 70
75 72 71 64 63 65
99 97 92 91 89 88 88
43 41 40 39 38 35 30 26
62 61 59 52 47
69 72 69 67 66 63 62
31 33 30 27 29
6 7 5 4 2 2
32 35 32 30 29 25
77 80 79 76 73 72 65
15 16 15 18 15 13
93 94 93 91 88 89 92
89 91 94 93 92 89 89
33 36 34 35 32 31 27
84 86 85 83 85 83 77
52 55 52 52 51 50
98 99 96 93 92 92 89 90
76 79 77 76 73 73 73
18 21 20 18 16 16 12
57 58 58 56 55 52 50 44
41 42 40 39 35 34 31
16 17 15 13 11 7 8
68 71 67 64 61 61
82 83 79 78 77 73
69 71 68 64 63 61 54
20 22 15 14 12
49 50 45 42 43
94 96 89 86 86
41 43 40 38 35 32 26 22
23 24 18 17 10
27 27 25 22 21
27 27 26 24 23 22 20 23
54 54 53 51 49 46 44 44
81 81 79 78 75 72 71 67
52 52 51 50 48 45 43 36
43 43 40 43 41
74 74 77 75 73 70 72
84 84 81 83 82 82
12 12 11 12 8
67 67 64 65 62 57
33 33 31 28 28 27
6 6 6 5 4 6
32 32 31 31 29 29
17 17 17 15 12 11 7
46 46 43 42 39 39 33
45 45 43 41 40 36 35
21 21 18 16 12 11 14
67 67 63 60 59 58 58
53 53 52 48 45 41
39 39 35 32 29 28 22
67 67 66 64 58 57 56
67 67 64 61 55 52 51 53
76 76 74 71 66 64 64
45 45 38 37 33
99 99 98 97 90 85
16 12 11 9 6 3 2
32 28 26 23 22 20 17 20
40 36 35 33 33
86 82 80 77 73
55 51 48 45 44 38
68 64 62 61 59 62 59 56
57 53 55 53 56
56 52 55 53 51 50 50
28 24 22 23 21 18 14
99 95 93 92 91 92 87
69 65 63 60 60 58 56
46 42 39 37 37 38
34 30 30 27 27
74 70 70 68 65 61
31 27 27 26 23 16
70 66 65 61 60
98 94 92 90 89 86 82 85
18 14 11 7 6 3 3
92 88 85 81 80 78 75 71
97 93 92 88 87 84 78
22 18 11 10 9 6
39 35 33 30 24 21 24
24 20 19 14 11 8 7 7
30 26 24 17 13
88 84 77 75 73 71 65
72 67 64 63 62 61 58 55
32 26 24 23 26
34 27 26 25 22 20 18 18
21 15 13 12 10 8 4
86 80 79 76 73 71 64
85 79 77 74 75 72 69
65 58 55 57 54 53 56
82 77 75 78 78
47 40 39 40 39 37 33
57 50 51 49 46 41
42 35 34 32 29 29 26
38 31 28 25 25 26
98 93 93 91 91
59 54 54 52 48
59 53 50 49 47 46 46 41
87 81 79 75 73
49 42 40 36 33 34
46 41 37 34 33 33
51 44 42 40 38 35 31 27
47 41 37 35 30
69 62 60 57 51 50
73 67 64 59 57 54 52 53
35 30 23 22 21 19 19
24 17 10 8 4
75 69 68 67 60 59 56 51
28 32 34 37 38 38 41 42
4 1 3 1 1
26 32 35 36 37 40 43
48 44 43 46 43 42 45
43 43 41 41 39 38 35 34
71 67 68 67 62
84 80 77 73 72 71 67
57 61 62 63 64 65 68 72
78 83 80 82 79
52 52 55 56 57 60 63 63
75 75 72 70 66 64
14 15 13 12 13 16
54 58 60 62 64 67 67
52 54 55 60 60
56 56 58 61 63 64 67 69
48 51 53 56 57 61 64
61 68 70 73 74 75 76 74
43 43 45 47 49 48 52
42 40 39 38 37 34 31 31
92 92 91 86 85 82 80 83
52 50 48 45 48
68 65 67 71 71
48 45 47 49 51 52 52
72 72 75 76 74
83 79 75 74 73 72 70
32 38 36 39 40 42 42
30 33 35 35 40
85 78 75 68 68
65 69 70 72 78 79 84
99 94 91 88 87 86 85 81
6 5 7 6 6
7 5 3 5 8 13
78 79 77 75 73 66 59
44 42 41 39 36 32 30
7 9 11 12 14 17 24 28
32 36 38 39 42 44 48 51
45 49 51 57 59 63
66 60 56 53 55
24 27 28 33 34
27 29 25 23 22 24
59 58 60 59 57 50
69 72 73 75 76 76 80
56 51 54 53 52 45
17 18 17 14 10 8 5
32 33 34 36 36 36
24 29 32 33 30 32 33 37
49 49 52 53 51 53 55 61
62 62 65 67 65 68 69 68
49 55 57 59 63
44 46 43 42 39 35 28
54 54 56 58 58 59 63
82 78 71 68 67 60
30 31 30 28 22 20 17 19
79 76 75 78 79
60 57 59 62 59
74 72 73 74 79 84
35 31 33 31 30 29 27 27
66 65 63 61 61 58 59
21 19 26 27 29 32 32
49 46 47 47 47
79 85 88 93 95 99
71 74 69 66 64 62 60 59
57 61 64 67 68 75
18 20 23 23 24 26 24
69 69 64 62 58
75 70 67 61 58 54
46 46 50 51 52 49
93 95 95 94 93
36 36 35 34 31 24 19
58 62 65 67 70
19 15 13 13 10 11
63 61 63 61 60 59 58 54
53 53 53 55 56
17 21 23 24 31 33 34 31
31 24 24 23 17
45 45 42 40 38 36 36
11 17 22 23 24 25 24
27 27 30 28 27 24 23 19
96 98 95 95 95
39 39 39 37 36 32
22 24 18 17 13
13 17 20 20 22 26
55 62 63 65 69 73
89 82 81 79 79
90 90 86 84 81 80 80
78 73 70 67 68 67 66 66
32 39 41 43 47 50 51
78 76 77 78 82 89
23 23 26 28 32
63 65 64 64 65
2 6 8 15 17 17
53 48 47 49 46 45 43
35 30 29 28 26
36 36 34 32 29 23
42 43 44 47 46 49
61 67 70 70 77
63 60 65 67 70 67
10 10 12 9 6 5 2 3
40 42 46 49 50 50
54 61 63 61 64 66 72
85 84 82 80 78 76 76 70
63 67 70 77 78 81
84 83 81 79 78 77
30 31 32 34 37 40 41 43
36 37 39 40 42 44 46
91 89 87 86 83
85 83 80 79 76
89 88 85 83 81
36 33 32 29 26 24 23
36 39 40 43 45 46 48 49
64 61 59 58 56 55 52 51
84 83 82 80 78
18 19 21 23 25
15 13 11 10 7 4
42 43 46 49 50 52 54
38 36 35 32 30 28 26 23
34 32 30 28 25
46 44 42 40 37 34
37 36 35 33 30 27 26 25
75 74 71 69 68 65 62
34 37 38 39 42 43 46
69 68 66 65 64 63
58 59 62 63 66
81 78 76 73 72
86 84 83 80 78 76 74 73
63 61 58 57 56 54 53 52
40 37 34 33 31 28 27
46 43 40 37 36 34
8 9 11 13 14 17
29 26 25 23 21 18 15
2 5 7 8 11 14 15 16
71 69 67 66 65 63 62
13 14 15 16 19 21
23 25 28 29 30 31 34
20 22 24 25 28 31
85 84 82 79 77 75 74 72
79 78 77 74 71 68 65 64
72 70 67 66 64 63 62
80 77 76 75 72 71 68
40 42 44 45 47 50
91 89 88 87 85 83 81
53 52 49 48 46 44 42
44 47 49 51 53 54 57 59
66 65 63 62 59 56
33 34 36 37 40
80 81 82 84 87 89
26 29 30 31 32 34 35 38
63 60 59 57 56 54
67 70 72 75 77 80 81
77 76 74 73 72 69 67 66
73 75 77 80 81 84 87
97 94 91 90 89 87
49 51 52 55 57 59
77 79 81 83 86 88 91
88 91 94 95 96
13 12 9 8 5
36 35 33 32 31
87 85 84 82 79
25 28 31 34 36 39 41 43
75 78 81 82 84 87 89 92
28 31 33 36 39 41 43 44
11 14 16 17 19
80 79 76 75 72 69 68 67
80 83 84 86 88 89 91
13 14 17 20 22 24 27
17 20 23 25 26 28 30 31
47 48 50 53 55 57
61 62 65 68 71 74
70 69 68 67 66 65
91 90 87 86 84 83 80
65 66 68 71 74 75 77 80
21 18 15 12 9 7 6
17 20 21 22 25 28
79 80 81 83 86 87
21 18 17 15 13
96 95 92 89 88
67 66 64 62 59 58
20 17 14 13 11 8 6 4
41 38 37 34 33 31 29
47 44 41 39 37
11 8 6 4 3 2 1
62 61 59 56 53 52 49
53 50 48 45 43 40 37 34
62 59 58 57 56 53 51
47 44 43 42 41 40 37
39 40 42 43 46 48 49
86 83 80 78 75 72 71 68
5 6 8 9 12 13 14
33 34 37 40 41 42
92 89 86 83 80 78
82 85 87 89 92 93 95
70 68 66 64 63 62 59
65 63 60 59 56 53 51
4 7 8 10 11 14 15
63 65 68 71 74 75 77
58 60 62 64 65 68 69
10 11 13 16 19
55 56 58 61 62
38 36 34 32 31 29 27
28 25 23 20 17 14
8 9 11 13 14 17 18
2 4 5 8 9
34 36 39 41 43 44 45 46
30 31 32 35 36 37 38
88 87 86 83 80
29 30 31 34 37 40 41
14 16 19 22 25
75 74 71 68 67
88 91 94 97 98
79 76 75 73 71 69 66 65
91 90 87 85 84 81
95 94 92 91 88 85
85 82 79 77 76 75 72 70
17 20 21 24 27 30 32
70 68 67 65 62 60 58
64 65 68 71 73
38 35 34 32 31 30
79 78 76 75 74
67 69 72 75 77 78
61 64 66 67 68 69
56 53 50 48 45
60 61 63 64 67
7 9 11 14 17 19 20 21
4 7 10 12 13
67 66 64 61 58 56
64 63 61 58 56 53 52 49
67 66 64 62 60 57 55
45 48 49 52 55 58
17 19 22 24 27
44 42 40 38 36 33 31
44 42 39 38 36 35
89 86 85 82 80 79
3 5 8 10 13 15 18
61 63 66 69 70 73 75
20 21 23 25 27 29 32 34
15 16 18 21 22 23
76 74 71 68 65 62 60
11 13 16 17 18 19
89 87 85 84 83
79 81 82 83 86
25 26 28 31 32 34 36
14 16 18 21 24 26 28
37 39 42 44 45 48 51
27 29 32 33 35 36 39
79 81 83 84 85 87
67 70 73 75 77
6 7 9 11 12
18 15 12 11 9
39 37 35 33 32 29 27
24 25 26 28 30 33 35 36
11 14 17 19 20 21 22
38 35 33 30 27 26
63 60 59 57 56 53
87 88 91 92 93 94 96 99
86 87 88 90 91 94
82 85 88 89 91 93 95
72 74 75 78 80 82 85
62 64 65 68 71 73
94 91 88 87 85
81 80 77 76 74 72 69 67
91 92 95 96 99
79 77 75 74 72 71
38 39 42 45 48
18 19 21 22 25 27 28
33 31 30 27 25 23 22
72 73 76 78 81 83 86 89
80 78 76 73 72 69 66 64
38 35 33 31 30 27
79 76 74 71 69 67
38 40 41 42 43 45 47 50
36 39 42 45 46 47 49
23 25 28 29 30 33
91 90 88 85 82 81
84 85 86 88 89 90
65 63 61 60 58 56
38 36 35 32 31
85 83 82 79 77 75 72
50 52 55 58 60 62 64
62 59 56 53 52
67 69 71 73 74 76
72 69 68 66 64 61
60 62 65 67 68 69 70
87 89 90 93 95 96
61 59 57 55 52 51 48 46
79 81 84 85 88 91
55 52 51 48 47 44
96 93 91 89 88 86
22 20 17 16 14 12
1 4 6 7 10 12 13
61 59 58 55 53
50 47 44 43 42 40 37 34
17 19 20 23 26
37 35 34 33 31 30 28 27
61 63 66 69 72
75 72 69 68 66
23 22 20 19 17 16 15 14
77 80 82 84 85 87
98 95 94 92 90 89
57 59 60 63 65 66 67 69
50 49 47 44 43 40
81 80 79 76 74 73 72 69
36 37 39 40 41 44
37 36 34 31 28
27 24 23 21 18
4 6 9 11 12 15
2 4 7 9 12
51 49 46 43 41 39 37 36
18 16 15 12 9 6
79 81 84 85 86
98 96 93 92 89 88 86 85
75 77 79 82 85
63 62 59 57 56 55 53
25 27 29 31 33
19 21 23 24 27 29 30
46 45 42 41 39 36 34 32
48 45 44 41 39 38 36
68 69 70 72 75 77 78 80
30 33 34 36 37 39
45 46 48 50 53 55 56
75 78 79 82 84 86 87
78 81 83 85 86
16 17 20 22 25 26 27
79 77 76 73 72 70 68
96 95 93 90 88 86 84 81
55 56 58 60 62
63 66 69 70 72 75 76 77
10 11 14 15 16 18
89 87 85 82 81 80 77 76
59 56 54 52 51 49
35 38 41 42 43
79 76 73 70 69 67
89 88 85 83 81 78 75 74
14 17 20 22 25 26 27
18 21 23 25 26 28 31 33
93 92 90 89 86
33 32 29 26 25 22
17 16 13 11 8
72 75 77 78 80 83
85 88 89 92 94
14 15 16 19 22
65 67 69 70 72 74 76 79
81 79 77 75 74 73 70
63 61 58 57 54
82 84 86 89 92 95
55 54 51 48 46
47 49 50 52 55 56 58
10 9 6 5 3
20 22 24 26 28 31
38 35 33 31 28 26
35 32 30 28 25 23 21 19
57 56 54 51 50 47
77 78 79 80 82
15 18 19 22 25 27 29 30
17 14 13 10 7 5
16 13 10 8 7
25 27 28 29 30 33 34 35
50 51 52 53 55
66 65 62 59 58 56 55 54
84 86 89 90 92
72 70 67 64 62 60 58
44 41 39 36 34 33
13 14 17 19 21 23 25
91 89 86 85 84
84 83 82 81 80 78 76 74
95 94 92 91 88
78 79 81 84 86 88 89
64 65 66 68 70 73 75 77
42 39 38 37 35
25 28 29 31 32 34 37 39
62 60 59 57 54
18 17 16 15 12 10 9
55 57 59 60 61
16 15 12 11 10 7 6 3
63 62 59 57 55 52
44 42 41 38 37
58 60 62 65 68 71 74
82 83 86 88 90 93 95
54 51 50 47 44
37 35 32 31 29 26 24
52 50 48 45 43 40 38
68 66 63 61 60 59
67 69 71 74 76 78
6 7 8 9 11 12
8 11 14 17 19 22 24 27
64 66 69 72 73 75 76
32 35 37 38 40 42 45 47
40 41 44 45 48
49 46 44 43 40
45 43 42 40 39 38
41 39 36 35 34 33 31 30
30 29 26 23 22
83 80 77 74 72 69 67
20 17 16 14 12 11 8
11 13 16 19 21 22 25 26
5 7 9 11 13 15 17 20
12 14 17 19 20
43 41 40 39 36
31 30 29 27 25 22 19
73 75 76 77 78 80 81
55 54 52 49 48 45 42
72 70 67 66 64 63 62 60
68 66 64 62 59 56 53 52
62 65 67 69 72
31 33 35 38 39 42 44 46
34 37 38 41 43 44 47
62 65 68 70 71 73
44 41 40 39 36 33 31 30
99 96 94 92 89 86
38 40 43 44 45 47
9 6 4 2 1
5 7 9 11 13 16 18
45 46 47 48 51 54 57 59
43 40 38 36 34 33 30
6 9 10 12 14 17
56 59 62 64 67
24 22 21 19 17 16
51 52 55 56 59 61 62 65
54 51 48 46 44 42 39 37
90 87 86 84 81 79 78
62 64 65 67 68 70
61 59 58 57 54 51 49
64 62 61 60 57
88 85 83 82 81 80
36 33 30 28 25
39 37 34 31 29 26 23 20
81 83 86 89 90
69 70 71 72 73 75 78 81
68 70 73 74 75 78 79 81
33 35 38 39 40 43 44 46
65 67 68 69 70
85 82 80 78 77 75
20 19 16 13 10 8 6
77 80 83 86 88 89 92
99 96 93 90 88 85 83 81
28 29 31 33 36 39
87 88 89 90 91
75 77 80 83 84 87 89 90
72 75 76 79 82 83 85
70 72 75 77 78 79 80
78 80 82 84 86
21 20 19 17 14 12 11 10
6 8 9 11 14
54 51 50 49 47
32 31 29 28 25 24 23
76 78 79 80 82 83 84
31 28 26 23 22
66 63 61 60 58
57 54 51 49 47 46
49 51 54 57 60 61 62
29 27 24 22 20 18 15 14
50 48 47 45 44 42 39
14 12 11 9 7 6 3
16 15 14 12 11 8
4 6 7 10 13 16 17 20
21 24 26 27 29 32
34 36 37 38 41 44
61 59 57 56 55 54 52
74 71 69 67 66 64 63 62
21 20 17 16 13 10
68 71 74 75 77 80
50 52 53 55 56 59 60
32 34 36 37 38
2 5 8 9 12 13 16
16 14 12 9 6 3
3 5 7 10 13 15 18 19
57 54 52 50 47
54 52 50 48 46
42 45 48 49 50
23 25 26 28 31 34
64 61 58 57 56 54
53 52 50 49 48 46 43
43 42 40 38 36 35 34
95 93 91 88 86 85
50 51 54 57 58 59 61 63
63 66 67 69 71 72
20 19 17 16 15 14 12
51 48 46 44 42
4 6 7 8 11 12 14 16
18 17 14 12 11 10
90 91 92 93 95 96 98
59 57 56 54 52
76 74 71 69 67
43 40 39 38 35
17 20 23 26 29 31
76 73 70 69 68 65
25 24 23 20 19 17 16
69 67 65 64 61
49 46 43 40 39 37 34 31
43 40 37 35 32
25 28 29 31 34 37
52 51 48 47 45 43 42
24 21 20 17 16 15 13 11
74 73 71 70 68
9 10 11 13 15 18 20
64 61 59 57 56 55
35 32 30 28 25 24
18 19 22 23 24 27 29
47 45 42 41 38 37 34 32
70 69 66 63 62
20 17 14 13 12 11 8 5
9 7 6 4 2
88 90 92 93 96 99
75 76 77 78 80 83 84 86
72 71 69 68 67 64";
    }
}
