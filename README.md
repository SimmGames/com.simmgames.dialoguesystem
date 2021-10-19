# Dialogue System v2.0.2
# About
[To-Do](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#to-do) | [Manual](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#manual) | [Scripting API](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#scripting-api)

The Dialogue System is a GraphView based Dialogue Editor and Storage system built-in with Unity3D. 

It includes a graph to create the flow of dialogue trees and a way to read and step through the tree.

The tree is composed of Nodes. There's a handful of basic nodes built in that can be (In the future) built upon to expand their functionality.

The nodes also allow for custom C# code for Condition checking and straight-up script. You can then use the in-editor compiler to check your work.

The Dialogue Graph can be opened in **Window\>Dialogue System\>Dialogue Graph**. Here you can do all of the dialogue editing you need.

![Dialogue Graph Screenshot](https://raw.githubusercontent.com/SimmGames/ProductionTools/main/Wiki/DialogueSystem/DialogueGraph.png)

# How To Install

1. Open up Unity's Package Manager (**Window\>Package Manager**)
2. In the top left, hit the **Plus** button and select **Add package from git URL...**
3. In the box, paste the package's git repository `https://github.com/SimmGames/com.simmgames.dialoguesystem.git` then hit Add
4. Everything should be installed after that! Samples are located at **Packages\>Dialogue System\>Samples**

# To-Do
- [ ]  Create Separate File to define Nodes [#13](https://github.com/SimmGames/ProductionTools/issues/13)
- [ ]  Add an End Node [#14](https://github.com/SimmGames/ProductionTools/issues/14)
- [ ]  Allow Node Clipboard Functions [#15](https://github.com/SimmGames/ProductionTools/issues/15)
- [ ]  Update the Editor Only Script API

***

# Manual

### Table Of Contents
* [Toolbar and Context Menu](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#toolbar-and-context-menu)
* [Dialogue Manager](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#dialogue-manager)
* [Nodes](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#nodes)
  * [Start Node](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#start-node)
  * [Dialogue Node](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#dialogue-node)
  * [Condition Node](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#condition-node)
  * [Event Node](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#event-node)
  * [Variable Node](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#variable-node)
  * [Chat Node](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#chat-node)
  * [Exit Node](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#exit-node)

## Toolbar and Context Menu

![Dialogue Graph Context Menu Screenshot](https://raw.githubusercontent.com/SimmGames/ProductionTools/main/Wiki/DialogueSystem/ContextMenu.png)

This is the dialogue graph's context menu and toolbar. From here, you can load, save, create nodes, and compile the dialogue code.
Do note: The Duplicate option (as well as the cut, copy, and paste ones) are not implemented and will not work.

1. Here is where you will name your dialogue file. This will be turned into an asset that's stored at "Resources/DialogueTrees/". You're allowed to make subfolders, but you will need to type that into the dialogue manager as well to access the correct dialogue tree.
2. This will save your dialogue tree to an asset. It will overwrite any file without asking, so be careful! 
3. This will load a dialogue tree into the dialogue graph. Make sure you saved your previous work before loading a new file!
4. This button will build a script file for your dialogue graph. This is required before running the dialogue tree. After this runs, your dialogue tree will likely reset, so make sure you save it before generating the script. You can then use Unity's compiler to figure out where your bad code is. All the functions in the generated script are marked with a GUID which is also marked on each Node.
5. This will create a [Dialogue Node](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#dialogue-node).
6. This will create a [Condition Node](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#condition-node)
7. This will create a [Event Node](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#event-node).
8. This will create a [Variable Node](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#variable-node).
9. This will create a [Chat Node](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#chat-node).

## Dialogue Manager

![Dialogue Manager](https://raw.githubusercontent.com/SimmGames/ProductionTools/main/Wiki/DialogueSystem/DialogueManager.png)

The Dialogue Manager is a MonoScript written to help you navigate the Dialogue System.

The only exposed field is to put in a Dialogue Tree. Please put in the same value you would on the Dialogue Graph.

For details on how to integrate the Dialogue Manager, please see the [Scripting API](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#dialoguemanager) for it.

## Nodes

The dialogue graph is made up of a number of different nodes. By connecting these nodes and populating them, you can make a dialogue tree! Just know, you can only have 1 chat/dialogue node coming from the outputs. Having multiple may lead to unexpected results (and you won't be warned if you do so). Just be careful!

All of the code in the nodes will be marked by Red Fields. Conditions will be treated as If statements. Events and Variables are full code, so make sure you use a Semi-Colon. All code is in C#.

### Start Node

![Start Node](https://raw.githubusercontent.com/SimmGames/ProductionTools/main/Wiki/DialogueSystem/StartNode.png)

The Start node is where you will enter the graph. Anything after this node will be run first.

### Dialogue Node

![Dialogue Node](https://raw.githubusercontent.com/SimmGames/ProductionTools/main/Wiki/DialogueSystem/DialogueNode.png)

The Dialogue Node offers splitting dialogue options for a player to pick from. In the top right, you can use the "+" button to add new choices. The "-" next to a choice will remove them. 

In the grey boxes for each choice is the text that will be returned for that choice. The condition box, in red, will determine when a choice will be available.

The Character Name is the name of a character who is speaking. The Dialogue Text is the dialogue to be displayed as well.

The Audio File field is a text field so you can process your audio later on.

If you are good at coding, you're able to expand these fields to hold more info. Check out the [Scripting API](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-Systemt#scripting-api) for more info.

### Condition Node

![Condition Node](https://raw.githubusercontent.com/SimmGames/ProductionTools/main/Wiki/DialogueSystem/ConditionNode.png)

A Condition Node will apply the condition (in red). If the condition passes, all the Pass nodes will run, and if it fails, the Fail nodes will run.

### Event Node

![Event Nodes](https://raw.githubusercontent.com/SimmGames/ProductionTools/main/Wiki/DialogueSystem/EventNode.png)

An Event Node will run whatever code in the Code field when it is called.

### Variable Node

![Variable Nodes](https://raw.githubusercontent.com/SimmGames/ProductionTools/main/Wiki/DialogueSystem/VariableNode.png)

A Variable Node is much like an event node, but it is run outside of a method and will allow you to declare local variables for the entire dialogue tree. These variables are specific to the tree and are not shared between trees.

If you would like to use a variable in your text fields, please use ${variableName}.

As an example, say you have a name you want to use in a text field. First, initialize your variable:

`string name = "Joe Mama";`

Inside of a TextField, you would then write:

`My name? My name is ${name}!`

And our final output would be:

`My name? My name is Joe Mama!`

If a variable can't be found, a warning will be shown in the Console and the variable won't be replaced.

### Chat Node

![Chat Nodes](https://raw.githubusercontent.com/SimmGames/ProductionTools/main/Wiki/DialogueSystem/ChatNode.png)

A Chat node is the same as a [Dialogue Node]() but it doesn't allow for any branching dialogue options.

### End Node
**This node has yet to be implemented.**

An End Node will end the dialogue where you're at. All events will still run, but the dialogue manager will be marked as no longer being in a conversation and thus will no longer return node data. An end node is virtually added to any output port without a node on it.

***

# Scripting API

### Table of Contents
* Runtime Scripts
  * [DialogueManager](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#dialoguemanager)
  * [NodeData](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#nodedata)
  * [NodeLinkData](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#nodelinkdata)
  * [NodeTypeEnum](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#nodetypeenum)
  * [DialogueContainer](https://github.com/SimmGames/ProductionTools/wiki/Dialogue-System#dialoguecontainer)
* Editor Scripts
  * TODO
## Runtime Scripts
The following scripts will run during the runtime of the game. It is recommended not to mess with these scripts as they can corrupt your dialogue assets.

## DialogueManager
The dialogue manager is the front end of the dialogue system. From here you can utilize the dialogue asset built with the dialogue graph.

The script will start from the Start Node and will go through and pick the next Chat/Dialogue node until it gets to the end of the tree.

### Exposed Fields
| Field | Return Type | Description |
| --- | --- | --- |
| DialogueName | string | The name of the Dialogue Asset to load from Resources/DialogueTrees. This is only exposed in Unity Editor | 

### Public Properties
| Property | Return Type | Description |
| --- | --- | --- |
| DialogueText | string | The Dialogue Text of the Current Node |
| Character | string | The Character Text of the Current Node |
| AudioFile | string | The Audio File text of the Current Node |
| DialogueOptions | Dictionary<string, string\> | A Dictionary of dialogue options with the Key as the Option Text and the Value as the Option GUID. The GUID will need to be returned later to proceed through a choice |
| InConversation | bool | When a conversation this will be true. When a conversation has reached its end, this will return false |

### Public Methods
| Method | Return Type | Description |
| --- | --- | --- |
| StartConversation() | void | This will enable a conversation from the beginning while preserving the variables from the previous time it was run |
| Reset() | void | This will reset a conversation and clearing all the previous variables in the process |
| SetDialogue(DialogueContainer newDialogue) | void | Sets the working dialogue tree. This will overwrite the current one! |
| Next(string optionGUID) | void | Gets ready for the next dialogue piece from the branch specified by the optionGuid. This is only run when you have a choice Guid to return |
| Next() | void | Gets ready for the next dialogue piece. Only run when you don't have a Guid to return |
| GetField(string fieldName)| string | Use this method to grab a text field of the current node that hasn't been predefined. |

## NodeData
The Node Data will store all of the data about the nodes themselves. If you want to use the TextFields Dictionary, you will have to un the DeSerialize() function first to make sure that the field is populated.

### Public Properties
| Property | Return Type | Description |
| --- | --- | --- |
| Guid | string | The GUID of the Node |
| Position | Vector2 | A x,y position of the node for the Dialogue Graph. This isn't used at runtime |
| Type | NodeType | The type of node this data is for |
| TextFields | Dictionary<string, string\> | This is a list of all the text fields attached to the node. Make sure you run DeSerialize() if you're accessing this data since it's not stored as a Dictionary in the Dialogue Asset. The first value is the Field Name and the second is the Field Value |

### Public Methods
| Method | Return Type | Description |
| --- | --- | --- |
| Serialize() | void | This encodes Textfields in internal fields to get serialized for storage. |
| DeSerialize() | void | This decodes the internal fields into the TextFields Dictionary |

## NodeLinkData

This is the storage container for all of the links between nodes. All ports using this data are output ports. There is always only one input port for every node so those are ignored.

### Public Properties
| Property | Return Type | Description |
| --- | --- | --- |
| BaseNodeGuid | string | The GUID of the node this port belongs to |
| PortName | string | The name/value inside of this port |
| PortGuid | string | The GUID of this specific port |
| Condition | string | The condition attached to this port. This string itself does not check the condition |
| TargetNodeGuid | string | The Guid of the node that this port is pointing at |

## NodeTypeEnum
These are the different types of nodes there are. They are listed as flags but are generally not used as such.

Note: Branch and Condition are the same value as they refer to the same type of node.

| Enum | Value |
| --- | --- |
| Entry | 1 << 1 |
| Dialogue | 1 << 2 |
| Chat | 1 << 3 |
| Variable | 1 << 4 |
| Branch | 1 << 5 |
| Condition | 1 << 5 |
| Event | 1 << 6 |
| Exit | 1 << 7 |
| None| 0 |

## DialogueContainer 
This is the actual Dialogue Asset used in the Dialogue Manager.

### Public Properties
| Property | Return Type | Description |
| --- | --- | --- |
| DialogueName | string | The name of the dialogue tree. This is also the name of the asset file |
| EntryPointGUID | string | This is the entry point's GUID that can be used to figure out what nodes come next |
| NodeLinks | List<NodeLinkData\> | A list of all the node links in the tree |
| Nodes | List<NodeData\> | A list of all of the nodes in the tree |

## Editor Scripts
The following scripts are only run in the Unity Editor. It is recommended not to mess with these scripts too much.

This section is currently unavailable. More expandability will be added later.