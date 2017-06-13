using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
namespace Small_World_Phenomenon
{

    public class movies
    {

        public int i = 0;
        public string ss = "";
        // display degrees and relations
        public int degree;
        public int relation;
        public List<int> degrees = new List<int>();
        public List<int> relations = new List<int>();
        public List<string> finalChain = new List<string>();
        // attributes of node
        public int[] color;
        public int[] parent;

        // use in function Dijkstra_Algo
        public int[] counts;
        public int[] rel;
        public Stack<int> ChainStack = new Stack<int>();

        public Dictionary<Tuple<int, int>, List<string>> commonMovies2actor = new Dictionary<Tuple<int, int>, List<string>>();

        public int countt;
        public int temp;
        public int count = -1;
        public List<string> ls = new List<string>();
      
        public Queue<int> q = new Queue<int>();
        public Dictionary<string, int> ActorId = new Dictionary<string, int>(); //key movie: values:actors
        public List<Tuple<string, string>> actors = new List<Tuple<string, string>>(); //two actors in quary file
        public Dictionary<int, List<int>> neighbours = new Dictionary<int, List<int>>();
        public List<string> lisofChain = new List<string>();


        public void  declare(){
            counts = new int[count + 1]; //O(1)
            rel = new int[count + 1];   //O(1)
            color = new int[count + 1];  //O(1)
            parent = new int[count + 1];  //O(1)
           }
        //read movies file and add in  dictionarys
        public void read_movie() //O(N+LM)
        {
            FileStream f = new FileStream("Movies187.txt", FileMode.Open, FileAccess.Read);//O(1)
            StreamReader Sr = new StreamReader(f);//O(1)
            int id1, id2;
            while (Sr.Peek() != -1)//(LM) LM:number of  lines in movie file
            {

                string s = Sr.ReadLine();//O(1)
                ls = s.Split('/').ToList();//O(1)
                string movie = ls[0];//O(1)
             //   ls.RemoveAt(0);//O(W) W:words        

                // to remove the name of movie
                for (int k = 1; k < ls.Count - 1; k++)//O(AL) number of actors in  each line
                {
                    id1 = getID(ls[k]); //O(N)number of actors

                    for (int j = k + 1; j < ls.Count; j++)//O(AL) number of actors in  each line
                    {

                        id2 = getID(ls[j]);//O(N)number of actors
                        FullCommonMoviesBetweenTwoActors(id1, id2, movie);//O(N) number of element in TwoActor dictionary
                        FullNeighbours(id1, id2);        //O(N)    number of element in   neibourse dicyionary       
                    }
                }
            }
           
            Sr.Close(); //O(1)
            declare();  //O(1)
        }
        //read from query file and add in actors  list of pair
        public void read_query() 
        {
            FileStream fs = new FileStream("queries50.txt", FileMode.Open, FileAccess.ReadWrite);//O(1)
            StreamReader s = new StreamReader(fs);//O(1)
            while (s.Peek() != -1)  //O(Lq)Lq:number of  lines in qurey file
            {
                string str = s.ReadLine();//O(1)
                string[] filed1 = str.Split('/');//O(1)
                var key1 = filed1[0];//O(1)
                var key2 = filed1[1];//O(1)
                int id1 = ActorId[key1];//O(1)
                int id2 = ActorId[key2];//O(1)
                actors.Add(Tuple.Create(filed1[0], filed1[1]));//O(1)
                Dijkstra_Algo(id1, id2);//O(N+E)
                backtrackChainList(id1, id2);//O(C) number of  elements  in   actors chain        
                degrees.Add(degree);//O(1)
                relations.Add(relation);//O(1)
                finalChain.Add(get_chainList());//O(1)
              
            }
            s.Close();//O(1)

        }
        public void writeinQuarysolution() //O(A) actors.Count//write result in quarysolution file
        {
            FileStream f = new FileStream("query solution.txt", FileMode.Create, FileAccess.Write);//O(1)
            StreamWriter sw = new StreamWriter(f);//O(1)
            string s = "Query" + "\t" + "\t" + "Deg." + "\t" + "\t" + "Rel." + "\t" + "\t" + "Chain";//O(1)
            sw.WriteLine(s);//O(1)
            for (int j = 0; j < actors.Count; j++)//O(A) actors.Count
            {
                s = actors[j].Item1 + "/" + actors[j].Item2 + "\t" + degrees[j] + "\t" + relations[j] + "\t" + finalChain[j];//O(1)
                sw.WriteLine(s);//O(1)
            }
            sw.Close();//O(1)
        }

        public int getID(string s) //O(N)//get id foreach actor
        {

            foreach (var v in ActorId)//O(N)
            {
                if (s.Equals(v.Key))//O(1)
                {
                    return v.Value;//O(1)
                }

            }
            count++;//O(1)
            ActorId.Add(s, count);   //dictionary that include nameofActors and it's id  
            return count;//O(1)
        }
        public void FullNeighbours(int from, int to)//O(N)
        {
            List<int> NeighboursTo = new List<int>();
            List<int> NeighboursFrom = new List<int>();
            int countTo = 0;//O(1)
            int countFrom = 0;//O(1)
            foreach (var v in neighbours)//O(N)number of actors
            {

              if (v.Key == to && !(v.Value.Contains(from)))//O(1)
                {
                    v.Value.Add(from);//O(1)

                    break;//O(1)
                }
                if (v.Key == to && (v.Value.Contains(from)))//O(1)
                {
                    break;//O(1)
                }
                countTo++;//O(1)
            }
            NeighboursTo.Add(from);//O(1)
            if (countTo == neighbours.Count)//O(1) // first movie between two actors in chainlist
                neighbours.Add(to, NeighboursTo);//O(1)
            foreach (var v in neighbours)//O(N)
            {
                if (v.Key == from && !(v.Value.Contains(to)))//O(1)
                {
                    v.Value.Add(to);//O(1)
                    break;//O(1)
                }
                if (v.Key == from && (v.Value.Contains(to)))//O(1)
                {
                    break;
                }
                countFrom++;//O(1)
            }
            NeighboursFrom.Add(to);//O(1)
            if (countFrom == neighbours.Count) //O(1)// first movie between two actors in chainlist
                neighbours.Add(from, NeighboursFrom);//O(1)

        }
        public void FullCommonMoviesBetweenTwoActors(int from, int to, string name)
        {
            List<string> s = new List<string>(); //O(1)
            int cnt = 0;//O(1)
            foreach (var v in commonMovies2actor)//O(p)  number of pair of actors
            {
                if (v.Key.Item1 == from && v.Key.Item2 == to) //O(1)
                {
                    v.Value.Add(name);//O(1)
                    break;//O(1)
                }
                cnt++;//O(1)
            }

            s.Add(name);//O(1)
            if (cnt == commonMovies2actor.Count)//O(1)
            {// first movie between two actors in chainlist
                commonMovies2actor.Add(Tuple.Create(from, to), s);//O(1)
                commonMovies2actor.Add(Tuple.Create(to, from), s);//O(1)
            }


        }

        public void intialize()//O(N)
        {
            for (int i = 0; i < count + 1; i++)//O(count of all actors in program)
            {

                counts[i] = 0; ; //O(1)
                rel[i] = 0; //O(1)
                color[i] = 0; //O(1)
                parent[i] = 0; //O(1)
            }

            q.Clear(); //O(1)

        }

        public void Dijkstra_Algo(int id1, int id2)//O(\N+E)
        {

            intialize(); //O(N)
            List<string> list = new List<string>(); //O(1)
            q.Enqueue(id1);      //O(1)
            while (q.Count != 0)//O(E)number of edges
            {
                temp = q.Dequeue();// O(1)
                if (temp == id2) //O(1)
                {
                    degree = counts[temp]; //O(1)
                    relation = rel[temp]; //O(1)
                }
                List<int> n = new List<int>(); 
                var k = temp;   //O(1)
                var ne = neighbours[k];  //O(1)
                foreach (var v in ne)//O(NE)number of neibours
                {
                    if (color[v] == 0)//O(1)
                    {
                        color[v] = 1; //O(1)
                        parent[v] = temp;  //O(1)
                        counts[v] = counts[temp] + 1;  //O(1)
                        var key = Tuple.Create(v, temp);    //O(1)
                        var m = commonMovies2actor[key]; //O(1)
                        if (rel[v] < rel[temp] + m.Count)   //O(1) //rel is ditance 
                        {
                            rel[v] = rel[temp] + m.Count; //O(1)
                        }
                        q.Enqueue(v); //O(1)
                        color[temp] = 2; //O(1)

                    }
                }
            }
        }
        public string get_chainList()//O(N)
        {
            ss = "";//O(1)
            i = 0;//O(1)
            int countstack = ChainStack.Count();//O(1)
            int fristelement = ChainStack.Pop();//O(1)
            int secondelement = ChainStack.Pop();//O(1)
            do
            {

                foreach (var v in commonMovies2actor)//O(2*N)
                {
                    if (v.Key.Item1 == fristelement && v.Key.Item2 == secondelement || v.Key.Item2 == fristelement && v.Key.Item1 == secondelement)//O(1)
                    {
                        lisofChain = v.Value;//O(1)
                        if (ChainStack.Count != 0)//O(1)
                        {

                            fristelement = secondelement;//O(1)
                            secondelement = ChainStack.Pop();//O(1)
                            if (ChainStack.Count == 0)//O(1)
                            {
                                countt = 1;//O(1)
                            }
                            else
                            {
                                countt = 1;//O(1)
                            }
                        }
                        else
                        {
                            countt = 0;//O(1)
                        }

                        break;//O(1)
                    }
                }
                i++;//O(1)

                for (int j = 0; j < lisofChain.Count; j++)//O(M) number movies between 2 actors
                {
                    ss += lisofChain[j];//O(1)
                    if (j != lisofChain.Count - 1)//O(1)
                        ss += " or ";//O(1)
                }
                if (i < countstack - 1)//O(1)
                    ss += " => ";//O(1)
            } while (countt != 0);//O(1)
            return ss;//O(1)
        }

        public void backtrackChainList(int id1, int id2)//O(C) number of  elements  in   actors chain        
        {

            int Parent;
            ChainStack.Push(id2);//O(1)
            do
            {
                Parent = parent[id2];//O(1)
                ChainStack.Push(Parent);//O(1)
                id2 = Parent;//O(1)
            } while (Parent != id1);//O(C) number of  elements  in   actors chain 



        }
    }
}

