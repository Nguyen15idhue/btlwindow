# HƯỚNG DẪN TÁI CẤU TRÚC MÃ NGUỒN

## ⚠️ CÁC BƯỚC THỰC HIỆN:

### Bước 1: Đóng Visual Studio
Đóng hoàn toàn Visual Studio trước khi thực hiện các bước tiếp theo.

### Bước 2: Tạo file btlwindow.csproj mới

Mở PowerShell tại thư mục `firstapp` và chạy lệnh sau:

```powershell
@"
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="`$(MSBuildExtensionsPath)\`$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('`$(MSBuildExtensionsPath)\`$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '`$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '`$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{A5A9657C-A7FB-4627-9E73-1AFD6893AB2F}</ProjectGuid>
    <OutputType>WinExe</OutputType>
    <RootNamespace>btlwindow</RootNamespace>
    <AssemblyName>firstapp</AssemblyName>
    <TargetFrameworkVersion>v4.8</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>
    <Deterministic>true</Deterministic>
  </PropertyGroup>
  <PropertyGroup Condition=" '`$(Configuration)|`$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '`$(Configuration)|`$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="BouncyCastle.Cryptography, Version=2.0.0.0, Culture=neutral, PublicKeyToken=072edcf4a5328938, processorArchitecture=MSIL">
      <HintPath>..\packages\BouncyCastle.Cryptography.2.6.2\lib\net461\BouncyCastle.Cryptography.dll</HintPath>
    </Reference>
    <Reference Include="Google.Protobuf, Version=3.32.0.0, Culture=neutral, PublicKeyToken=a7d26565bac4d604, processorArchitecture=MSIL">
      <HintPath>..\packages\Google.Protobuf.3.32.0\lib\net45\Google.Protobuf.dll</HintPath>
    </Reference>
    <Reference Include="K4os.Compression.LZ4, Version=1.3.8.0, Culture=neutral, PublicKeyToken=2186fa9121ef231d, processorArchitecture=MSIL">
      <HintPath>..\packages\K4os.Compression.LZ4.1.3.8\lib\net462\K4os.Compression.LZ4.dll</HintPath>
    </Reference>
    <Reference Include="K4os.Compression.LZ4.Streams, Version=1.3.8.0, Culture=neutral, PublicKeyToken=2186fa9121ef231d, processorArchitecture=MSIL">
      <HintPath>..\packages\K4os.Compression.LZ4.Streams.1.3.8\lib\net462\K4os.Compression.LZ4.Streams.dll</HintPath>
    </Reference>
    <Reference Include="K4os.Hash.xxHash, Version=1.0.8.0, Culture=neutral, PublicKeyToken=32cd54395057cec3, processorArchitecture=MSIL">
      <HintPath>..\packages\K4os.Hash.xxHash.1.0.8\lib\net462\K4os.Hash.xxHash.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.Bcl.AsyncInterfaces, Version=5.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51, processorArchitecture=MSIL">
      <HintPath>..\packages\Microsoft.Bcl.AsyncInterfaces.5.0.0\lib\net461\Microsoft.Bcl.AsyncInterfaces.dll</HintPath>
    </Reference>
    <Reference Include="MySql.Data, Version=9.6.0.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d, processorArchitecture=MSIL">
      <HintPath>..\packages\MySql.Data.9.6.0\lib\net48\MySql.Data.dll</HintPath>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Buffers, Version=4.0.3.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51, processorArchitecture=MSIL">
      <HintPath>..\packages\System.Buffers.4.5.1\lib\net461\System.Buffers.dll</HintPath>
    </Reference>
    <Reference Include="System.Configuration" />
    <Reference Include="System.Configuration.Install" />
    <Reference Include="System.Core" />
    <Reference Include="System.Diagnostics.DiagnosticSource, Version=7.0.0.2, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51, processorArchitecture=MSIL">
      <HintPath>..\packages\System.Diagnostics.DiagnosticSource.7.0.2\lib\net462\System.Diagnostics.DiagnosticSource.dll</HintPath>
    </Reference>
    <Reference Include="System.IO.Pipelines, Version=5.0.0.2, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51, processorArchitecture=MSIL">
      <HintPath>..\packages\System.IO.Pipelines.5.0.2\lib\net461\System.IO.Pipelines.dll</HintPath>
    </Reference>
    <Reference Include="System.Management" />
    <Reference Include="System.Memory, Version=4.0.1.2, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51, processorArchitecture=MSIL">
      <HintPath>..\packages\System.Memory.4.5.5\lib\net461\System.Memory.dll</HintPath>
    </Reference>
    <Reference Include="System.Numerics" />
    <Reference Include="System.Numerics.Vectors, Version=4.1.4.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL">
      <HintPath>..\packages\System.Numerics.Vectors.4.5.0\lib\net46\System.Numerics.Vectors.dll</HintPath>
    </Reference>
    <Reference Include="System.Runtime.CompilerServices.Unsafe, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL">
      <HintPath>..\packages\System.Runtime.CompilerServices.Unsafe.6.0.0\lib\net461\System.Runtime.CompilerServices.Unsafe.dll</HintPath>
    </Reference>
    <Reference Include="System.Threading.Tasks.Extensions, Version=4.2.0.1, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51, processorArchitecture=MSIL">
      <HintPath>..\packages\System.Threading.Tasks.Extensions.4.5.4\lib\net461\System.Threading.Tasks.Extensions.dll</HintPath>
    </Reference>
    <Reference Include="System.Transactions" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Deployment" />
    <Reference Include="System.Drawing" />
    <Reference Include="System.Net.Http" />
    <Reference Include="System.Windows.Forms" />
    <Reference Include="System.Xml" />
    <Reference Include="ZstdSharp, Version=0.8.6.0, Culture=neutral, PublicKeyToken=8d151af33a4ad5cf, processorArchitecture=MSIL">
      <HintPath>..\packages\ZstdSharp.Port.0.8.6\lib\net462\ZstdSharp.dll</HintPath>
    </Reference>
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Forms\Form1.cs">
      <SubType>Form</SubType>
    </Compile>
    <Compile Include="Forms\Form1.Designer.cs">
      <DependentUpon>Form1.cs</DependentUpon>
    </Compile>
    <Compile Include="Forms\frmAddTask.cs">
      <SubType>Form</SubType>
    </Compile>
    <Compile Include="Forms\frmAddTask.Designer.cs">
      <DependentUpon>frmAddTask.cs</DependentUpon>
    </Compile>
    <Compile Include="Forms\frmLogin.cs">
      <SubType>Form</SubType>
    </Compile>
    <Compile Include="Forms\frmLogin.Designer.cs">
      <DependentUpon>frmLogin.cs</DependentUpon>
    </Compile>
    <Compile Include="Forms\frmRegister.cs">
      <SubType>Form</SubType>
    </Compile>
    <Compile Include="Forms\frmRegister.Designer.cs">
      <DependentUpon>frmRegister.cs</DependentUpon>
    </Compile>
    <Compile Include="Controls\TaskItem.cs">
      <SubType>UserControl</SubType>
    </Compile>
    <Compile Include="Controls\TaskItem.Designer.cs">
      <DependentUpon>TaskItem.cs</DependentUpon>
    </Compile>
    <Compile Include="Models\TaskModel.cs" />
    <Compile Include="Models\UserModel.cs" />
    <Compile Include="Repositories\TaskRepository.cs" />
    <Compile Include="Repositories\UserRepository.cs" />
    <Compile Include="Program.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
    <EmbeddedResource Include="Forms\Form1.resx">
      <DependentUpon>Form1.cs</DependentUpon>
    </EmbeddedResource>
    <EmbeddedResource Include="Forms\frmAddTask.resx">
      <DependentUpon>frmAddTask.cs</DependentUpon>
    </EmbeddedResource>
    <EmbeddedResource Include="Forms\frmLogin.resx">
      <DependentUpon>frmLogin.cs</DependentUpon>
    </EmbeddedResource>
    <EmbeddedResource Include="Forms\frmRegister.resx">
      <DependentUpon>frmRegister.cs</DependentUpon>
    </EmbeddedResource>
    <EmbeddedResource Include="Controls\TaskItem.resx">
      <DependentUpon>TaskItem.cs</DependentUpon>
    </EmbeddedResource>
    <EmbeddedResource Include="Properties\Resources.resx">
      <Generator>ResXFileCodeGenerator</Generator>
      <LastGenOutput>Resources.Designer.cs</LastGenOutput>
      <SubType>Designer</SubType>
    </EmbeddedResource>
    <Compile Include="Properties\Resources.Designer.cs">
      <AutoGen>True</AutoGen>
      <DependentUpon>Resources.resx</DependentUpon>
    </Compile>
    <None Include="Documentation\AUTHENTICATION_GUIDE.md" />
    <None Include="Documentation\DOCUMENTATION.md" />
    <None Include="Documentation\QUICKSTART.md" />
    <None Include="packages.config" />
    <None Include="Properties\Settings.settings">
      <Generator>SettingsSingleFileGenerator</Generator>
      <LastGenOutput>Settings.Designer.cs</LastGenOutput>
    </None>
    <Compile Include="Properties\Settings.Designer.cs">
      <AutoGen>True</AutoGen>
      <DependentUpon>Settings.settings</DependentUpon>
      <DesignTimeSharedInput>True</DesignTimeSharedInput>
    </Compile>
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
  </ItemGroup>
  <ItemGroup>
    <Content Include="Database\database_update.sql" />
    <Content Include="Database\database_with_auth.sql" />
  </ItemGroup>
  <ItemGroup>
    <Folder Include="Models\" />
    <Folder Include="Repositories\" />
    <Folder Include="Forms\" />
    <Folder Include="Controls\" />
    <Folder Include="Database\" />
    <Folder Include="Documentation\" />
  </ItemGroup>
  <Import Project="`$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
</Project>
"@ | Out-File -FilePath "btlwindow.csproj" -Encoding UTF8
```

### Bước 3: Mở lại Visual Studio
Mở lại solution trong Visual Studio. Visual Studio sẽ tự động reload project với cấu trúc mới.

### Bước 4: Reload Solution
- Nếu Visual Studio yêu cầu reload, chọn "Reload All"
- Nếu không, đóng và mở lại solution

## 📁 CẤU TRÚC THƯ MỤC MỚI:

```
firstapp/
├── Forms/                    # Tất cả các Windows Forms
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── Form1.resx
│   ├── frmAddTask.cs
│   ├── frmAddTask.Designer.cs
│   ├── frmAddTask.resx
│   ├── frmLogin.cs
│   ├── frmLogin.Designer.cs
│   ├── frmLogin.resx
│   ├── frmRegister.cs
│   ├── frmRegister.Designer.cs
│   └── frmRegister.resx
├── Controls/                 # User Controls
│   ├── TaskItem.cs
│   ├── TaskItem.Designer.cs
│   └── TaskItem.resx
├── Models/                   # Data Models
│   ├── TaskModel.cs
│   └── UserModel.cs
├── Repositories/             # Data Access Layer
│   ├── TaskRepository.cs
│   └── UserRepository.cs
├── Database/                 # SQL Scripts
│   ├── database_with_auth.sql
│   └── database_update.sql
├── Documentation/            # Documentation files
│   ├── AUTHENTICATION_GUIDE.md
│   ├── DOCUMENTATION.md
│   └── QUICKSTART.md
├── Properties/               # Assembly info và resources
│   ├── AssemblyInfo.cs
│   ├── Resources.resx
│   ├── Resources.Designer.cs
│   ├── Settings.settings
│   └── Settings.Designer.cs
├── Program.cs                # Entry point
├── App.config                # Configuration
├── packages.config           # NuGet packages
└── btlwindow.csproj          # Project file
```

## ✅ LỢI ÍCH CỦA CẤU TRÚC MỚI:

1. **Tổ chức rõ ràng**: Mỗi loại file có thư mục riêng
2. **Dễ bảo trì**: Tìm kiếm và quản lý file dễ dàng hơn
3. **Theo chuẩn**: Tuân thủ best practices của .NET
4. **Scalability**: Dễ dàng mở rộng khi thêm tính năng mới
5. **Team work**: Nhiều người có thể làm việc song song dễ dàng

## 🔧 KHẮC PHỤC SỰ CỐ:

Nếu vẫn gặp lỗi sau khi reload:
1. Clean Solution: Build > Clean Solution
2. Rebuild Solution: Build > Rebuild Solution
3. Close và reopen Visual Studio
4. Xóa thư mục `bin` và `obj`, sau đó rebuild

## 📝 LƯU Ý:

- Tất cả namespace vẫn giữ nguyên là `btlwindow`
- Không cần thay đổi code trong các file .cs
- Chỉ cần cập nhật file .csproj để Visual Studio nhận biết vị trí mới của các file
