using System;
using System.Collections.Generic;
using System.Linq;

namespace TheStoryTelling
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = ReadGraph();
            var dependencies = GetDependencies(graph);
            Console.WriteLine(GetGraphOrder(graph, dependencies));
        }

        private static string GetGraphOrder(Dictionary<string, List<string>> graph, Dictionary<string, List<string>> dependencies)
        {
            List<string> removedElements = new List<string>();
            while (graph.Count != 0)
            {
                var dependency = dependencies.Reverse().FirstOrDefault(d => d.Value.Count == 0);
                var currentNode = dependency.Key;
                var children = graph[currentNode];
                foreach (var child in children)
                {
                    dependencies[child].Remove(currentNode);
                }
                graph.Remove(currentNode);
                dependencies.Remove(currentNode);
                removedElements.Add(currentNode);
            }

            return string.Join(" ", removedElements);

        }


        private static Dictionary<string, List<string>> GetDependencies(Dictionary<string, List<string>> graph)
        {
            var dependencies = new Dictionary<string, List<string>>();
            foreach (var node in graph)
            {
                foreach (var child in node.Value)
                {
                    if (dependencies.ContainsKey(child))
                    {
                        dependencies[child].Add(node.Key);
                    }
                    else
                    {
                        dependencies.Add(child, new List<string> { node.Key });
                    }
                }
                if (!dependencies.ContainsKey(node.Key)) dependencies.Add(node.Key, new List<string>());
            }

            return dependencies;
        }


        private static Dictionary<string, List<string>> ReadGraph()
        {
            string input;
            var graph = new Dictionary<string, List<string>>();
            while ((input = Console.ReadLine()) != "End")
            {
                var first = input.Split(" ->", StringSplitOptions.None)[0];
                var second = new List<string>();
                if (input.Split(" -> ", StringSplitOptions.None).Length != 1) second = input.Split(" -> ", StringSplitOptions.None)[1].Split().ToList();

                if (!graph.ContainsKey(first))
                {
                    graph.Add(first, second);
                }
                else
                {
                    graph[first].AddRange(second);
                }
            }

            return graph;
        }
    }
}
